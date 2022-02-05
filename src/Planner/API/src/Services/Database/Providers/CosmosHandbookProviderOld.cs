using Azure.Security.KeyVault.Secrets;
using Courseloop.DataAccess;
using Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using HXR.Utilities.DateTime;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using Planner.Models.Course;

namespace Planner.Api.Services.Database.Providers {
    public class CosmosHandbookProviderOld : IMacquarieHandbook {
        private readonly CosmosClient cosmosClient;
        private readonly Microsoft.Azure.Cosmos.Database database;
        private readonly Container courseContainer;
        private readonly Container unitContainer;
        private readonly ILogger<CosmosHandbookProviderOld> _logger;
        private readonly IMemoryCache _cache;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly JsonSerializer _jsonSerialiser;

        // TODO Review cosmosdb provider
        // Extending IMacquarieHandbook is not going to work as both will handle different types (MacquarieUnit vs UnitDto).
        // Might have to move IMacquarieHandbook out of its current namespace/project and make it return the Dtos.
        // That would require all providers handle mapping.

        public CosmosHandbookProviderOld(IConfiguration configuration, ILogger<CosmosHandbookProviderOld> logger, IMemoryCache cache, IDateTimeProvider dateTimeProvider, JsonSerializer jsonSerialiser) {
            var cosmosConnectionString = configuration.GetValue<string>(configuration["Azure:KeyVault:CosmosConnectionStrings:Read"]);

            cosmosClient = new CosmosClient(cosmosConnectionString);
            database = cosmosClient.GetDatabase(configuration["Azure:Cosmos:DatabaseId"]);

            courseContainer = database.GetContainer(configuration["Azure:Cosmos:Containers:Course"]);
            unitContainer = database.GetContainer(configuration["Azure:Cosmos:Containers:Unit"]);
            _logger = logger;
            _cache = cache;
            _dateTimeProvider = dateTimeProvider;
            _jsonSerialiser = jsonSerialiser;
        }

        public Task<MacquarieDataCollection<MacquarieCourse>> GetAllCourses(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public Task<MacquarieDataCollection<MacquarieUnit>> GetAllUnitsAsync(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public async Task<MacquarieCourse> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
            if (implementationYear is null) {
                implementationYear = _dateTimeProvider.DateTimeNow.Year;
            }

            // Build a key based upon CourseCode.Year i.e. C00105.2022
            string itemKey = $"{courseCode.ToUpper()}.{implementationYear}";

            if (_cache.TryGetValue<CourseDto>(itemKey, out CourseDto course)) {
                //return course;
            }
            
            using (ResponseMessage responseMessage = await courseContainer.ReadItemStreamAsync(
                    partitionKey: new PartitionKey(courseCode[..4]),
                    id: itemKey)) {
                if (responseMessage.IsSuccessStatusCode) {
                    return FromStream<MacquarieCourse>(responseMessage.Content);
                } else {
                    return new MacquarieCourse() { Code = "Not Found" };
                }
            }

            // //Throws exception if resource is not found, thus has an overhead for misses.
            // try {
            //     var result = await courseContainer.ReadItemAsync<MacquarieCourse>(courseCode, new(implementationYear.ToString()), new(), cancellationToken);
            //     if (result.StatusCode == System.Net.HttpStatusCode.OK) {
            //         return result.Resource;
            //     }
            // } catch (CosmosException cosmosEx) when (cosmosEx.StatusCode == System.Net.HttpStatusCode.NotFound) { }

            //return new MacquarieCourse() { Code = "Not Found" };
        }

        //https://github.com/Azure/azure-cosmos-dotnet-v3/blob/63f4799b5eb7192401159548e346cb383570e07b/Microsoft.Azure.Cosmos.Samples/Usage/ItemManagement/Program.cs#L431
        private T FromStream<T>(Stream stream) {
            using (stream) {
                if (typeof(Stream).IsAssignableFrom(typeof(T))) {
                    return (T)(object)(stream);
                } 

                using (StreamReader sr = new StreamReader(stream)) {
                    using (JsonTextReader jsonTextReader = new JsonTextReader(sr)) {
                        return _jsonSerialiser.Deserialize<T>(jsonTextReader);
                    }
                }
            }
        }

        public async Task<MacquarieUnit> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
            return await unitContainer.ReadItemAsync<MacquarieUnit>(unitCode, new(implementationYear.ToString()), new(), cancellationToken);
        }

        Task<MacquarieDataCollection<MacquarieCourse>> IMacquarieHandbook.GetAllCourses(int? implementationYear, int limit, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }

        Task<MacquarieDataCollection<MacquarieUnit>> IMacquarieHandbook.GetAllUnits(int? implementationYear, int limit, CancellationToken cancellationToken) {
            throw new NotImplementedException();
        }
    }
}