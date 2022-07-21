using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Planner.Api.Services.DataAccess;
using Planner.Models.Shared;

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

            return Ok(await SerialiseAll(units, "Units", year, cancellationToken));
    }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAllDataFromUnitContainer(int year = 2022, CancellationToken cancellationToken = default) {
            var units = await _cosmos.GetAllUnits(year.ToString());

            return Ok(await SerialiseAll(units, "Units", year, cancellationToken));
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> DownloadAllDataFromCourseContainer(int year = 2022, CancellationToken cancellationToken = default) {
            var courses = await _cosmos.GetAllCourses(year.ToString() + "handbooks");

            return Ok(await SerialiseAll(courses, "Course", year, cancellationToken));
      }

        public async ValueTask<string> SerialiseAll<T>(List<T> collection, string dataType, int year, CancellationToken ct) where T : MetadataDto {
            if (!collection.Any()) {
                return string.Empty;
            }

            string path = $"Archive/{dataType}/ImplYear_{year}";
            Directory.CreateDirectory(path);
            foreach (var item in collection) {
                var json = JsonConvert.SerializeObject(item, Formatting.Indented, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
                string filePath = $"{path}/{item.Code}.json";
                await System.IO.File.WriteAllTextAsync(filePath, json, cancellationToken: ct);
            }

            string msg = $"{collection.Count} {dataType} have been downloaded and saved.";
            _logger.LogInformation(msg);

            return msg;
        }
    }
}