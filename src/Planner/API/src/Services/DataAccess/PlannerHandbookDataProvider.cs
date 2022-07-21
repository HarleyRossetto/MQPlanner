namespace Planner.Api.Services.DataAccess;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Courseloop.DataAccess;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using HXR.Utilities.DateTime;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Caching.Memory;
using Planner.Models.Course;
using Planner.Models.Unit;

public class PlannerHandbookDataProvider : IHandbookDataProvider {
    private readonly ILogger<PlannerHandbookDataProvider> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IMemoryCache _memoryCache;
    private readonly CosmosHandbookDataProvider _cosmosHandbookDataProvider;
    private readonly MacquarieHandbook _courseloopHandbookDataProvider;
    private readonly IMapper _mapper;
    private IEnumerable<string> cosmosUnitIds;

    public PlannerHandbookDataProvider(ILogger<PlannerHandbookDataProvider> logger, IDateTimeProvider dateTimeProvider, IMemoryCache memoryCache, CosmosHandbookDataProvider cosmosHandbookDataProvider, MacquarieHandbook courseloopHandbookDataProvider, IMapper mapper) {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _memoryCache = memoryCache;
        _cosmosHandbookDataProvider = cosmosHandbookDataProvider;
        _courseloopHandbookDataProvider = courseloopHandbookDataProvider;
        _mapper = mapper;
    }

    public async Task<List<UnitDto>> GetAllUnits(int? implementationyear, CancellationToken cancellationToken = default) {
        var sw = Stopwatch.StartNew();
        var units = await _courseloopHandbookDataProvider.GetAllUnits(implementationyear, 4000, cancellationToken);
        sw.Stop();
        _logger.LogInformation("All units retrieved from source in {0} seconds", sw.Elapsed.TotalSeconds);

        sw.Restart();
        List<UnitDto> mappedUnits = new();

        foreach (var unit in units) {
            mappedUnits.Add(_mapper.Map<MacquarieUnit, UnitDto>(unit));
        }
        sw.Stop();
        _logger.LogInformation("Mapping data completed in {0} seconds.", sw.Elapsed.TotalSeconds);

        var aggeratedRequestUnits = 0.0D;
        var savedUnits = 0;
        
        // Uses a lot of Request Units
        var cosmosUnitIds = await _cosmosHandbookDataProvider.GetAllUnitIds(implementationyear, cancellationToken);

        sw.Restart();
        foreach (var unit in mappedUnits) {
            // Do we need to archive the unit?
            if (cosmosUnitIds.Contains(unit.Code)) {
                //Get the unit from cosmos
                // Also uses a lot of Request Units over time.
                var cosmosUnit = await _cosmosHandbookDataProvider.GetUnit(unit.Code,
                                                                    int.Parse(unit.ImplementationYear!),
                                                                    cancellationToken);

                // If the cosmos unit is not null, archive it.
                if (cosmosUnit is not null && cosmosUnit.Version != unit.Version) {
                    _logger.LogInformation("Replacing {0} v.{1} with v.{2}", cosmosUnit.Code, cosmosUnit.Version, unit.Version);
                    //_logger.LogInformation("CosmosUnit {0} with version {1} and Courseloop {2} with version {3}", cosmosUnit.Code, cosmosUnit.Version, unit.Code, unit.Version);
                    var cosmosItemResponse =
                        await _cosmosHandbookDataProvider.ArchiveUnitToCosmos(
                            cosmosUnit,
                            cancellationToken);
                    _logger.LogInformation(cosmosItemResponse.ToString());
                }
            }

            // Dont use cosmos types and name spaces here, they dont belong and are out of scope of this class.
            var response = await _cosmosHandbookDataProvider.SaveUnitToCosmos(unit, cancellationToken);
            if (response is not null) {
                if (response.StatusCode == System.Net.HttpStatusCode.Created) {
                    savedUnits++;
                }
                aggeratedRequestUnits += response.RequestCharge;
            }
        }

        sw.Stop();

        _logger.LogInformation("{0} units saved to Cosmos costing {1} RUs taking {2}. RUs per second {3}", savedUnits, aggeratedRequestUnits, sw.Elapsed, aggeratedRequestUnits / sw.Elapsed.TotalSeconds);

        return new();
    }

    public async Task<CourseDto?> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        var cacheKey = courseCode.ToUpper();

        if (_memoryCache.TryGetValue<CourseDto>(cacheKey, out var cachedCourse)) {
            _logger.LogInformation("Course with code: {0} retrieved from cache", cachedCourse.Code);
            return cachedCourse;
        }

        var cosmosCourse = await _cosmosHandbookDataProvider.GetCourse(courseCode, implementationYear, cancellationToken);
        if (cosmosCourse?.Code == courseCode.ToUpper()) {
            _logger.LogInformation("Course with code: {0} retrieved from cosmos", cosmosCourse.Code);
            return _memoryCache.Set(cosmosCourse.Code, cosmosCourse, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            //return cosmosCourse;
        }

        var courseloopCourse = await _courseloopHandbookDataProvider.GetCourse(courseCode, implementationYear, cancellationToken);
        if (courseloopCourse is not null && courseloopCourse.Code == courseCode.ToUpper()) {
            var course = _mapper.Map<CourseDto>(courseloopCourse);

            var cosmosRecord = await _cosmosHandbookDataProvider.SaveCourseToCosmos(course, cancellationToken);

            _logger.LogInformation("Course with code: {0} retrieved from CourseLoop", course.Code);
            return _memoryCache.Set(course.Code, course, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
        }

        return null;
    }

    public Task<IEnumerable<CourseDto>> GetCoursesWithNameContainer(string courseName, int? implementationYear = null, CancellationToken cancellationToken = default) {
        return _cosmosHandbookDataProvider.GetCoursesWithNameContainer(courseName, implementationYear, cancellationToken);
    }

    private bool TryGetUnitFromCache(string unitCode, int? implmentationYear, out UnitDto cachedUnit) {
        var cacheKey = (unitCode.ToUpper(), implmentationYear.ToString());
        
        if (_memoryCache.TryGetValue<UnitDto>(cacheKey, out var unit)) {
            cachedUnit = unit;
            return true;
        }

        cachedUnit = new();
        return false;
    }

    
    // private UnitDto SaveUnitToCache(UnitDto unit) {
    //      // If the unit code matches and the unit was retrieved in the last 30 days
    //     if (unit is not null &&
    //         //unit.Code.Equals(unitCode, StringComparison.OrdinalIgnoreCase) &&
    //         _dateTimeProvider.DateTimeNow.Subtract(unit.DateRetrieved).TotalDays < 30) {
    //         _logger.LogInformation("Unit with code: {0} retrieved from cosmos", unit.Code);
    //         var cacheKey = (unit.Code, unit.ImplementationYear);
    //         return _memoryCache.Set(cacheKey, unit, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
    //     }
    // }

    public async Task<UnitDto?> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        // Attempt to retreive unit from the cache.
        if (TryGetUnitFromCache(unitCode, implementationYear, out var cachedUnit)) {
            _logger.LogInformation("Unit with code: {0} retrieved from cache", cachedUnit.Code);
            return cachedUnit;
        }

        // Attempt to retreive the unit from Cosmos DB
        var cosmosUnit = await _cosmosHandbookDataProvider.GetUnit(unitCode, implementationYear, cancellationToken);

        // If the unit code matches and the unit was retrieved in the last 30 days
        // we will cache it and return it.
        if (cosmosUnit is not null &&
            cosmosUnit.Code.Equals(unitCode, StringComparison.OrdinalIgnoreCase) &&
            _dateTimeProvider.DateTimeNow.Subtract(cosmosUnit.DateRetrieved).TotalDays < 30) {
            _logger.LogInformation("Unit with code: {0} retrieved from cosmos", cosmosUnit.Code);
            var cacheKey = (cosmosUnit.Code, cosmosUnit.ImplementationYear);
            return _memoryCache.Set(cacheKey, cosmosUnit, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
        }

        // Finally attempt to retreive the unit from courseloop.
        var courseloopUnit = await _courseloopHandbookDataProvider.GetUnit(unitCode, implementationYear, cancellationToken);
        // courseloopUnit?.Code.Equals(unitCode, StringComparison.OrdinalIgnoreCase)?
        // If the result from courseloop is not null and code matches correctly map the unit to the domain transfer
        // object.
        // If we previously got a unit from cosmos but it was out of date, then we must archive the cosmos version.
        // Save the newly retrieved unit to cosmos, cache it and return.
        if (courseloopUnit is not null && courseloopUnit.Code.Equals(unitCode, StringComparison.OrdinalIgnoreCase)) {
            var unit = _mapper.Map<UnitDto>(courseloopUnit);

            // If there was a record in cosmos, but it is out of date then we need to archive so it can be replaced.
            if (cosmosUnit is not null) {
                //TODO archive.
                var cosmosItemResponse = await _cosmosHandbookDataProvider.ArchiveUnitToCosmos(cosmosUnit, cancellationToken);
                _logger.LogInformation(cosmosItemResponse.ToString());
            }

            var cosmosRecord = await _cosmosHandbookDataProvider.SaveUnitToCosmos(unit, cancellationToken);
            if (cosmosRecord?.StatusCode == System.Net.HttpStatusCode.Created) {
                _logger.LogInformation("Unit with code: {0} saved to CosmosDB using {1} RUs.", cosmosRecord.Resource.Code, cosmosRecord.RequestCharge);
            }

            _logger.LogInformation("Unit with code: {0} retrieved from CourseLoop", unit.Code);
            return _memoryCache.Set(unit.Code, unit, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
        }

        // Otherwise return 
        return null;
    }

    public async Task<IEnumerable<string>> GetAllUnitIds(int? implementationyear, CancellationToken cancellationToken = default) {
        return await _cosmosHandbookDataProvider.GetAllUnitIds(implementationyear, cancellationToken);
    }

    public async Task<bool> DeleteMessyArchive() {
        return await _cosmosHandbookDataProvider.DeleteMessyArchive();
    }
}