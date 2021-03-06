namespace Courseloop.DataAccess;

using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using HXR.Utilities.DateTime;
using Microsoft.Extensions.Logging;
using static Courseloop.Models.Json.Helpers.JsonSerialisationHelper;

public class MacquarieHandbook : IMacquarieHandbook
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<MacquarieHandbook> _logger;
    public TimeSpan WebRequestTimeout { get => _httpClient.Timeout; set => _httpClient.Timeout = value; }
    public IDateTimeProvider _dateTimeProvider { get; }

    public MacquarieHandbook(ILogger<MacquarieHandbook> handbookLogger, IDateTimeProvider _dateTimeProvider, HttpClient httpClient) {
        _logger = handbookLogger;
        this._dateTimeProvider = _dateTimeProvider;
        _httpClient = httpClient;
    }

    /// <summary>
    /// Downloads JSON data from the provided URL.
    /// In the even the http response from is not successful, an empty string is returned.
    /// </summary>
    /// <param name="url">The URL from which to download the JSON resource.</param>
    /// <returns>JSON retrieved from URL. In the event of a http failure, an empty string.</returns>
    public async Task<string> DownloadJsonDataFromUrl(string url, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Retrieving json data from {url}.", url);

        try {
            var response = await _httpClient.GetAsync(url, cancellationToken);

            if (response.IsSuccessStatusCode) {
                return await response.Content.ReadAsStringAsync(cancellationToken);
            }
            
            _logger.LogWarning("Http data request failed. Response: {response}", response);
        } catch (HttpRequestException ex) {
            _logger.LogError(ex, $"Http call failed with code: {ex.StatusCode}");
        } catch (Exception genericEx) {
            _logger.LogError(genericEx, "Unknown Http error occured.");
        }

        return string.Empty;
    }

    private async Task<MacquarieDataCollection<T>> DownloadDataAsCollection<T>(string url, CancellationToken cancellationToken = default) where T : MacquarieMetadata
    {
        var jsonString = await DownloadJsonDataFromUrl(url, cancellationToken);

        if (string.IsNullOrEmpty(jsonString))
        {
            return new();
        }
        else
        {
            return DeserialiseJsonObject<MacquarieDataCollection<T>>(jsonString);
        }
    }

    private async Task<MacquarieDataCollection<T>> DownloadDataAsCollection<T>(HandbookApiRequestBuilder apiRequest, CancellationToken cancellationToken = default) where T : MacquarieMetadata
    {
        return await DownloadDataAsCollection<T>(apiRequest.ToString(), cancellationToken);
    }

    public async Task<MacquarieUnit?> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default)
    {
        HandbookApiRequestBuilder apiRequestBuilder = new(unitCode, implementationYear, APIResourceType.Unit);
        var resultsCollection = await DownloadDataAsCollection<MacquarieUnit>(apiRequestBuilder);
        return resultsCollection.Collection.FirstOrDefault(defaultValue: null);
    }
    public async Task<MacquarieDataCollection<MacquarieUnit>> GetAllUnits(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default)
    {
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        _logger.LogInformation("Loading all unit data for {implementationYear}.", implementationYear);

        var apiRequest = new HandbookApiRequestBuilder() { ImplementationYear = implementationYear, Limit = limit, ResourceType = APIResourceType.Unit };
        return await DownloadDataAsCollection<MacquarieUnit>(apiRequest, cancellationToken);
    }

    public async Task<MacquarieCourse?> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default)
    {
        HandbookApiRequestBuilder apiRequestBuilder = new(courseCode, implementationYear, APIResourceType.Course);
        var resultsCollection = await DownloadDataAsCollection<MacquarieCourse>(apiRequestBuilder);
        return resultsCollection.Collection.FirstOrDefault(defaultValue: null);
    }

    public async Task<MacquarieDataCollection<MacquarieCourse>> GetAllCourses(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default)
    {
        //If the provided year is null, assume this current year.
        implementationYear ??= _dateTimeProvider.DateTimeNow.Year;

        var apiRequest = new CourseApiRequestBuilder() { ImplementationYear = implementationYear, Limit = limit };

        return await DownloadDataAsCollection<MacquarieCourse>(apiRequest);
    }
}