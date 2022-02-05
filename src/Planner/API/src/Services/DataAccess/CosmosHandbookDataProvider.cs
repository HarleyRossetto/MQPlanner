namespace Planner.Api.Services.DataAccess;

using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HXR.Utilities.DateTime;
using Microsoft.Azure.Cosmos;
using Newtonsoft.Json;
using Planner.Models.Course;
using Planner.Models.Shared;
using Planner.Models.Unit;

public class CosmosHandbookDataProvider : IHandbookDataProvider {
    private readonly ILogger<CosmosHandbookDataProvider> _logger;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JsonSerializer _jsonSerializer;
    private readonly CosmosClient cosmosClient;
    private readonly Database cosmosDatabase;
    private readonly Container cosmosUnitContainer;
    private readonly Container cosmosCourseContainer;

    public CosmosHandbookDataProvider(ILogger<CosmosHandbookDataProvider> logger, IDateTimeProvider dateTimeProvider, JsonSerializer jsonSerializer, IConfiguration cfg) {
        _logger = logger;
        _dateTimeProvider = dateTimeProvider;
        _jsonSerializer = jsonSerializer;

        cosmosClient = new(cfg.GetValue<string>(cfg["Azure:KeyVault:CosmosConnectionStrings:ReadWrite"]));
        cosmosDatabase = cosmosClient.GetDatabase(cfg["Azure:Cosmos:DatabaseId"]);

        string unitPartionKeyPath = $"/{nameof(UnitDto.ImplementationYear)}";
        cosmosUnitContainer = cosmosDatabase.CreateContainerIfNotExistsAsync(cfg["Azure:Cosmos:Containers:Unit"],
                                                                                unitPartionKeyPath).Result;

        string coursePartitionKeypath = $"/{nameof(CourseDto.UrlYear)}";
        cosmosCourseContainer = cosmosDatabase.CreateContainerIfNotExistsAsync(cfg["Azure:Cosmos:Containers:Course"],
                                                                               coursePartitionKeypath).Result;
        //cosmosUnitContainer = cosmosDatabase.GetContainer(cfg["Azure:Cosmos:Containers:Unit"]);
        // cosmosCourseContainer = cosmosDatabase.GetContainer(cfg["Azure:Cosmos:Containers:Course"]);
    }

    private void ValidateImplementationYear(ref int? implementationYear) {
        if (implementationYear is not null) {
            if (implementationYear > _dateTimeProvider.DateTimeNow.Year) {
                implementationYear = _dateTimeProvider.DateTimeNow.Year;
            }
        } else {
            implementationYear = _dateTimeProvider.DateTimeNow.Year;
        }
    }

    public async Task<CourseDto> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        string itemKey = courseCode.ToUpper();
        string partitionKey = $"{implementationYear.ToString()}handbooks";

        CourseDto? course = await ReadFromStreamAsync<CourseDto>(cosmosCourseContainer, new PartitionKey(partitionKey), itemKey, cancellationToken);

        return course ?? new CourseDto() { Code = "Course Not Found" };

    }

    public async Task<IEnumerable<CourseDto>> GetCoursesWithNameContainer(string courseName, int? implementationYear = null, CancellationToken cancellationToken = default) {
        ValidateImplementationYear(ref implementationYear);

        if (string.IsNullOrWhiteSpace(courseName)) {
            return new List<CourseDto>() { new CourseDto() { Code = "Course Not Found" } };
        }

        string queryString = $"SELECT c.Title FROM c WHERE CONTAINS(c.Title, \"{courseName}\", true)";

        return await RunQuery<CourseDto>(cosmosCourseContainer, queryString, $"{implementationYear}handbooks");

        QueryDefinition query = new QueryDefinition(queryString);
        //QueryDefinition query = new QueryDefinition($"SELECT * FROM Courses");
        List<CourseDto> results = new();

        string partitionKey = $"{implementationYear}handbooks";

        double aggerateRequestCharge = 0;

        using (FeedIterator<CourseDto> resultSetIterator =
            cosmosCourseContainer.GetItemQueryIterator<CourseDto>(query,
                                                                     requestOptions: new() { PartitionKey = new(partitionKey) })) {
            while (resultSetIterator.HasMoreResults) {
                FeedResponse<CourseDto> response = await resultSetIterator.ReadNextAsync();
                results.AddRange(response);

                aggerateRequestCharge += response.RequestCharge;
                _logger.LogInformation("RU: {0}", response.RequestCharge);

                if (response.Diagnostics != null) {
                    //_logger.LogError("{0}", response.Diagnostics.ToString());
                }
            }
        }

        _logger.LogInformation("Course Title Query ({0}) with partition key {1} returned {3} results consuming {4}RUs.",
                               query.QueryText,
                               partitionKey,
                               results.Count,
                               aggerateRequestCharge);

        return results;
    }

    private async Task<List<T>> RunQuery<T>(Container targetContainer, string queryString, string partitionKey = null) {
        if (targetContainer is null) {
            _logger.LogWarning("Parameter {0} of {1} cannot be null!", nameof(targetContainer), nameof(RunQuery));
            return new List<T>();
        }

        if (string.IsNullOrWhiteSpace(queryString)) {
            _logger.LogWarning("Parameter {0} of {1} cannot be null or whitespace!", nameof(queryString), nameof(RunQuery));
            return new List<T>();
        }

        QueryRequestOptions queryRequestOptions = null;

        if (partitionKey is not null) {
            queryRequestOptions = new() { PartitionKey = new(partitionKey) };
        }

        QueryDefinition queryDefinition = new(queryString);

        var results = new List<T>();
        double aggerateRequestCharge = 0;
        using (FeedIterator<T> resultSetIterator = targetContainer.GetItemQueryIterator<T>(queryDefinition,
                                                                                           requestOptions: queryRequestOptions)) {
            var response = await resultSetIterator.ReadNextAsync();
            results.AddRange(response);
            aggerateRequestCharge += response.RequestCharge;
        }

        _logger.LogInformation("Course Title Query ({0}) with partition key {1} returned {3} results consuming {4}RUs.",
                              queryDefinition.QueryText,
                              partitionKey,
                              results.Count,
                              aggerateRequestCharge);

        return results;
    }

    public async Task<UnitDto> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        //string itemKey = $"{unitCode.ToUpper()}.{implementationYear}";

        UnitDto? unit = await ReadFromStreamAsync<UnitDto>(cosmosUnitContainer,
                                                           new PartitionKey($"{implementationYear}"),
                                                           unitCode.ToUpper(),
                                                           cancellationToken);

        return unit ?? new UnitDto() { Code = "Course Not Found" };
    }

    private async Task<T?> ReadFromStreamAsync<T>(Container container, PartitionKey partitionKey, string id, CancellationToken cancellationToken = default) where T : MetadataDto {
        using (ResponseMessage responseMessage = await container.ReadItemStreamAsync(id, partitionKey, null, cancellationToken)) {
            if (responseMessage.IsSuccessStatusCode) {
                using (StreamReader reader = new StreamReader(responseMessage.Content)) {
                    using (JsonTextReader jsonTextReader = new(reader)) {
                        return _jsonSerializer.Deserialize<T>(jsonTextReader) ?? default(T);
                    }
                }
            } else {
                return default(T);
            }
        }
    }

    private async Task<Stream> ToStream<T>(T input) {
        MemoryStream payload = new MemoryStream();
        using (StreamWriter streamWriter = new StreamWriter(payload, encoding: Encoding.Default, bufferSize: 1024, leaveOpen: true)) {
            using (JsonWriter jsonWriter = new JsonTextWriter(streamWriter)) {
                jsonWriter.Formatting = Newtonsoft.Json.Formatting.None;
                _jsonSerializer.Serialize(jsonWriter, input);
                await jsonWriter.FlushAsync();  //TODO Async flush is used, synchronus option is available..
                await streamWriter.FlushAsync();
            }
        }

        payload.Position = 0;
        return payload;
    }



    public async Task<CourseDto> SaveCourseToCosmos(CourseDto course, CancellationToken cancellationToken = default) {
        using (Stream stream = await ToStream<CourseDto>(course)) {
            using (ResponseMessage response = await cosmosCourseContainer.CreateItemStreamAsync(stream, new PartitionKey(course.UrlYear))) {
                if (response.IsSuccessStatusCode) {
                     _logger.LogInformation("Course with code: {0} saved to CosmosDB using {1} RUs.", course.Code, response.Headers.RequestCharge);
                } else {
                    _logger.LogError("Save Course to Cosmos from stream failed. Status Code: {0} Message: {1}", response.StatusCode, response.ErrorMessage);
                }
            }
        }

        return course;
        //var partitionKey = new PartitionKey(course.UrlYear);
        //return await cosmosCourseContainer.CreateItemAsync(course, partitionKey, null, cancellationToken);
    }

    public async Task<ItemResponse<UnitDto>> SaveUnitToCosmos(UnitDto unit, CancellationToken cancellationToken) {
        var partitionKey = new PartitionKey(unit.ImplementationYear?.ToString());
        try {
            var itemResult = await cosmosUnitContainer.CreateItemAsync(unit, partitionKey, null, cancellationToken);
            return itemResult;
        } catch (CosmosException ex) {
            _logger.LogInformation(ex.Message);
        }
        return null!;
    }

    public async Task<List<UnitDto>> GetAllUnits(int? implementationYear, CancellationToken cancellationToken = default) {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        return await RunQuery<UnitDto>(cosmosUnitContainer, $"SELECT * FROM u", implementationYear.ToString());
    }
}
