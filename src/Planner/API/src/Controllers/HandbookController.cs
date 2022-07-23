namespace Planner.Api.Controllers;

using System.Threading.Tasks;
using AutoMapper;
using Courseloop.DataAccess;
using Courseloop.Models.Unit;
using HXR.Utilities.DateTime;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Planner.Api.Services.DataAccess;
using Planner.Models.Course;
using Planner.Models.Unit;

[ApiController]
[Route("[controller]")]
public class HandbookController : ControllerBase
{
    private readonly ILogger<HandbookController> _logger;
    private readonly IMacquarieHandbook _handbook;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly IMemoryCache _cache;
    private readonly IHandbookDataProvider _handbookDataProvider;
    private readonly IDateTimeProvider _dateTimeProvider;

    public HandbookController(ILogger<HandbookController> logger, IMacquarieHandbook handbook, IMapper mapper, IConfiguration configuration, IMemoryCache cache, IHandbookDataProvider handbookDataProvider, IDateTimeProvider dateTimeProvider) {
        _logger = logger;
        _handbook = handbook;
        _mapper = mapper;
        _configuration = configuration;
        _cache = cache;
        _handbookDataProvider = handbookDataProvider;
        _dateTimeProvider = dateTimeProvider;
    }

    [HttpGet("[action]/{unitCode}")]
    public async Task<UnitDto> GetUnit(string unitCode = "comp2160", [FromQuery] int? implementationYear = null, CancellationToken cancellationToken = default) {
        _logger.LogInformation("Attempting to retrieve data for {unitCode}", unitCode);

        // // TODO Review how best to implement cacheing across all data.
        // if (_cache.TryGetValue<UnitDto>(unitCode.ToUpper(), out UnitDto cachedUnit)) {
        //     return cachedUnit;
        // }
        
        // var unit = _mapper.Map<UnitDto>(await _handbook.GetUnitAsync(unitCode));

        // _cache.Set(unit.Code, unit, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1)));

        // return unit;\
        //TODO Change return type to IActionResult or similar
        return await _handbookDataProvider.GetUnit(unitCode, implementationYear, cancellationToken) ?? new();   
    }

     [HttpGet("[action]/{unitCode}")]
    public async Task<MacquarieUnit> GetCourseLoopUnit(string unitCode = "elec3042", [FromQuery] int? implementationYear = null, CancellationToken cancellationToken = default) {
        // _logger.LogInformation("Attempting to retrieve data for {unitCode}", unitCode);

        // // TODO Review how best to implement cacheing across all data.
        // if (_cache.TryGetValue<UnitDto>(unitCode.ToUpper(), out UnitDto cachedUnit)) {
        //     return cachedUnit;
        // }

        // var unit = _mapper.Map<UnitDto>(await _handbook.GetUnitAsync(unitCode));

        // _cache.Set(unit.Code, unit, new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromHours(1)));

        // return unit;
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;
        //TODO Change return type to IActionResult or similar
        return await _handbook.GetUnit(unitCode, implementationYear, cancellationToken) ?? new();
    }

    [HttpGet("[action]/{courseCode}")]
    public async Task<CourseDto> GetCourse(string courseCode = "C000105") {
        _logger.LogInformation("Attempting to retrieve data for {unitCode}", courseCode);
        // return _mapper.Map<CourseDto>(await _handbook.GetCourseAsync(courseCode));
        //TODO Change return type to IActionResult or similar
        return await _handbookDataProvider.GetCourse(courseCode) ?? new();
    }

    [HttpGet("[action]/{courseName}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CourseDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCoursesWithNameContaining(string courseName = "Information", [FromQuery] int? implementationYear = null, CancellationToken cancellationToken = default) {
        var result = await _handbookDataProvider.GetCoursesWithNameContainer(courseName, implementationYear);

        if (!result.Any()) {
            return NotFound();
        }
        
        return Ok(result);
    }

    // [HttpGet("[action]")]
    // public async Task<IActionResult> GetAllUnitsFromCourseLoop([FromQuery]int? implmentationYear = null, CancellationToken cancellationToken = default) {
    //     return Ok(await _handbookDataProvider.GetAllUnits(implmentationYear, cancellationToken));
    // }

    // [HttpGet("[action]")]
    // public async Task<IActionResult> GetAllUnitIds([FromQuery]int? implementationYear = null, CancellationToken ct = default) {
    //     return Ok(await _handbookDataProvider.GetAllUnitIds(implementationYear, ct));
    // }

    // [HttpGet("[action]")]
    // public async Task<IActionResult> Debug_DeleteMessyArchive() {
    //     return Ok(await _handbookDataProvider.DeleteMessyArchive());
    // }

   

    // [HttpGet("[action]/{courseCode}")]
    // public async Task<CurriculumStructureDataDto> GetCourseStructure(string courseCode = "C000006") {
    //     _logger.LogInformation("Attempting to retrieve data for {unitCode}", courseCode);
    //     return _mapper.Map<CurriculumStructureDataDto>((await _handbook.GetCourseAsync(courseCode)).CurriculumData);
    // }

    // [HttpGet("[action]")]
    // public async ValueTask<int> GetUnitCount(CancellationToken cancellationToken, int? implementationYear = null) {
    //     _logger.LogInformation("Attemping to retrieve all units to determine count");
    //     return (await _handbook.GetAllUnitsAsync(implementationYear: implementationYear, cancellationToken: cancellationToken)).Count;
    // }

    // [HttpGet("[action]")]
    // public async Task<IEnumerable<string>> GetAllUnitCodes(int? implementationYear = null) {
    //     var allUnits = await _handbook.GetAllUnitsAsync(implementationYear ?? int.Parse(_configuration["DefaultYear"]));

    //     if (allUnits is null)
    //         return new string[] { "Unable to access all unit data." };

    //     return from unit in allUnits.Collection
    //            select unit.Code;
    // }
}
