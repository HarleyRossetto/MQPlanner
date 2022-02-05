namespace Planner.Api.Services.DataAccess;

using System;
using System.Diagnostics;
using System.Threading.Tasks;
using AutoMapper;
using Courseloop.DataAccess;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using HXR.Utilities.DateTime;
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

    public PlannerHandbookDataProvider(ILogger<PlannerHandbookDataProvider> logger, IDateTimeProvider dateTimeProvider, IMemoryCache memoryCache, CosmosHandbookDataProvider cosmosHandbookDataProvider, MacquarieHandbook courseloopHandbookDataProvider, IMapper mapper) {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _memoryCache = memoryCache;
        _cosmosHandbookDataProvider = cosmosHandbookDataProvider;
        _courseloopHandbookDataProvider = courseloopHandbookDataProvider;
        _mapper = mapper;
    }

    public async Task<List<UnitDto>> GetAllUnits(int? implementationyear, CancellationToken cancellationToken = default) {
        var units = await _courseloopHandbookDataProvider.GetAllUnits(implementationyear, 4000, cancellationToken);
        List<UnitDto> mappedUnits = new();

        var sw = Stopwatch.StartNew();

        foreach (var unit in units) {
            mappedUnits.Add(_mapper.Map<MacquarieUnit, UnitDto>(unit));
        }
        sw.Stop();
        _logger.LogInformation("Mapping data completed in {0} seconds.", sw.Elapsed.TotalSeconds);

        var aggeratedRequestUnits = 0.0D;
        var savedUnits = 0;

        sw.Restart();
        foreach (var unit in mappedUnits) {
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

    public async Task<CourseDto> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        var cacheKey = courseCode.ToUpper();

        if (_memoryCache.TryGetValue<CourseDto>(cacheKey, out var cachedCourse)) {
            _logger.LogInformation("Course with code: {0} retrieved from cache", cachedCourse.Code);
            return cachedCourse;
        }

        var cosmosCourse = await _cosmosHandbookDataProvider.GetCourse(courseCode, implementationYear, cancellationToken);
        if (cosmosCourse.Code == courseCode.ToUpper()) {
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

        return new() { Code = "Course Not Found" };
    }

    public Task<IEnumerable<CourseDto>> GetCoursesWithNameContainer(string courseName, int? implementationYear = null, CancellationToken cancellationToken = default) {
        return _cosmosHandbookDataProvider.GetCoursesWithNameContainer(courseName, implementationYear, cancellationToken);
    }

    public async Task<UnitDto> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;
 
        var cacheKey = (unitCode.ToUpper(), implementationYear.ToString());

        if (_memoryCache.TryGetValue<UnitDto>(cacheKey, out var cachedUnit)) {
            _logger.LogInformation("Unit with code: {0} retrieved from cache", cachedUnit.Code);
            return cachedUnit;
        }

        var cosmosUnit = await _cosmosHandbookDataProvider.GetUnit(unitCode, implementationYear, cancellationToken);
        if (cosmosUnit.Code == unitCode.ToUpper()) {
            _logger.LogInformation("Unit with code: {0} retrieved from cosmos", cosmosUnit.Code);
            cacheKey = (cosmosUnit.Code, cosmosUnit.ImplementationYear);
            return _memoryCache.Set(cacheKey, cosmosUnit, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            //return cosmosCourse;
        }

        var courseloopUnit = await _courseloopHandbookDataProvider.GetUnit(unitCode, implementationYear, cancellationToken);
        if (courseloopUnit is not null && courseloopUnit.Code == unitCode.ToUpper()) {
            var unit = _mapper.Map<UnitDto>(courseloopUnit);

            var cosmosRecord = await _cosmosHandbookDataProvider.SaveUnitToCosmos(unit, cancellationToken);
            if (cosmosRecord.StatusCode == System.Net.HttpStatusCode.Created) {
                _logger.LogInformation("Unit with code: {0} saved to CosmosDB using {1} RUs.", cosmosRecord.Resource.Code, cosmosRecord.RequestCharge);
            }

            _logger.LogInformation("Unit with code: {0} retrieved from CourseLoop", unit.Code);
            return _memoryCache.Set(unit.Code, unit, new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1)));
            //return course;
        }

        return new() { Code = "Unit Not Found" };
    }
}