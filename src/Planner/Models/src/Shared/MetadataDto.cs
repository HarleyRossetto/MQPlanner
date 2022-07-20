namespace Planner.Models.Shared;

using System;
using Newtonsoft.Json;

public record MetadataDto
{
    //TODO DateTime.DateTimeNow could become some dependancy to allow unit testing?
    //Otherwise it should be set another way; considering this is a DTO it should be provided
    //by the original source, not set independantly.
    public DateTime DateRetrieved { get; init; } = DateTime.Now;
    public DateTime? ModificationDate { get; init; }
    public string Code { get; init; } = String.Empty;
    public string? Title { get; init; }
    public string? ImplementationYear { get; init; }
    public string? StudyLevel { get; init; }
    public string? ContentTypeLabel { get; init; }
    public bool Archived { get; init; }
    public bool Working { get; init; }
    public bool Locked { get; init; }
    public bool Live { get; init; }
    public string? UrlMapForContent { get; init; }
    public string? HostName { get; init; }

    /// <summary>
    /// Cosmos ID
    /// </summary>
    [JsonProperty("id")]
    public string? Id => $"{Code}{(Archived ? ModificationDate?.ToString(":yyyyMMddThhmmssZ") : "")}";
}
