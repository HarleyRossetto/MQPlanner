using Newtonsoft.Json;

namespace Planner.Models.Unit;

public record AssessmentDto
{
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? AssessmentTitle { get; init; } 
    public string? Type { get; init; } 
    public string? Weight { get; init; } 
    public string? Description { get; init; } 
    public string? AppliesToAllOfferings { get; init; } 
    public string? HurdleTask { get; init; } 
    public string? Offerings { get; init; } 
    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string? Individual { get; init; } 

    public override string ToString() => Description ?? string.Empty;
}
