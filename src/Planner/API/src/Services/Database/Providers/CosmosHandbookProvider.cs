using Courseloop.DataAccess;
using Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using Microsoft.Azure.Cosmos;

namespace Planner.Api.Services.Database.Providers {
    public class CosmosHandbookProvider : IMacquarieHandbook {

        private readonly CosmosClient cosmosClient;
        private readonly Microsoft.Azure.Cosmos.Database database;
        private readonly Container courseContainer;
        private readonly Container unitContainer;

        // TODO Review cosmosdb provider
        // Extending IMacquarieHandbook is not going to work as both will handle different types (MacquarieUnit vs UnitDto).
        // Might have to move IMacquarieHandbook out of its current namespace/project and make it return the Dtos.
        // That would require all providers handle mapping.

        public CosmosHandbookProvider(IConfiguration configuration) {
            cosmosClient = new CosmosClient(configuration["Cosmos:Endpoint"], configuration["Cosmos:PrimaryKey"]);
            database = cosmosClient.GetDatabase(configuration["Cosmos:DatabaseId"]);

            courseContainer = database.GetContainer(configuration["Cosmos:Containers:Course"]);
            unitContainer = database.GetContainer(configuration["Cosmos:Containers:Unit"]);
        }

        public Task<MacquarieDataCollection<MacquarieCourse>> GetAllCourses(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public Task<MacquarieDataCollection<MacquarieUnit>> GetAllUnits(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default) {
            throw new NotImplementedException();
        }

        public async Task<MacquarieCourse> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
            var result = await courseContainer.ReadItemAsync<MacquarieCourse>(courseCode, new(implementationYear.ToString()), new(), cancellationToken);
            if (result.StatusCode == System.Net.HttpStatusCode.OK) {
                return result.Resource;
            }

            return new MacquarieCourse() { Code = "Not Found" };
        }

        public async Task<MacquarieUnit> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
            return await unitContainer.ReadItemAsync<MacquarieUnit>(unitCode, new(implementationYear.ToString()), new(), cancellationToken);
        }
    }
}