using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.Api.Services.DataAccess;

namespace src.Controllers
{
    public class CosmosController : ControllerBase
    {
        private readonly CosmosHandbookDataProvider _cosmos;
        private readonly ILogger<CosmosController> _logger;
        public CosmosController(CosmosHandbookDataProvider cosmos, ILogger<CosmosController> logger) {
            _cosmos = cosmos;
            _logger = logger;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAllDataFromArchiveContainer(int year = 2022, CancellationToken cancellationToken = default) {
            var units = await _cosmos.GetAllUnitsFromArchive(year.ToString());

            if (!units.Any()) {
                return NoContent();
            }

            Directory.CreateDirectory($"Archive/ArchivedUnits/ImplYear_{year}");
            foreach (var unit in units) {
                var text = JsonConvert.SerializeObject(unit, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                await System.IO.File.WriteAllTextAsync($"Archive/ArchivedUnits/ImplYear_{year}/{unit.Code}.json", text);
            }

            return Ok($"{units.Count} units have been downloaded and saved.");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAllDataFromUnitContainer(int year = 2022, CancellationToken cancellationToken = default) {
            var units = await _cosmos.GetAllUnits(year.ToString());

            if (!units.Any()) {
                return NoContent();
            }

            Directory.CreateDirectory($"Archive/Units/ImplYear_{year}");
            foreach (var unit in units) {
                var text = JsonConvert.SerializeObject(unit, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                await System.IO.File.WriteAllTextAsync($"Archive/Units/ImplYear_{year}/{unit.Code}.json", text);
            }

            return Ok($"{units.Count} units have been downloaded and saved.");
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAllDataFromCourseContainer(int year = 2022, CancellationToken cancellationToken = default) {
            var units = await _cosmos.GetAllCourses(year.ToString() + "handbooks");

            if (!units.Any()) {
                return NoContent();
            }

            Directory.CreateDirectory($"Archive/Course/ImplYear_{year}");
            foreach (var unit in units) {
                var text = JsonConvert.SerializeObject(unit, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                await System.IO.File.WriteAllTextAsync($"Archive/Course/ImplYear_{year}/{unit.Code}.json", text);
            }
            string msg = $"{units.Count} units have been downloaded and saved.";
            _logger.LogInformation(msg);
            return Ok(msg);
        }
    }
}