namespace Planner.Models.Unit;

public record AssessmentDto
{
    public string AssessmentTitle { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string Weight { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string AppliesToAllOfferings { get; init; } = string.Empty;
    public string HurdleTask { get; init; } = string.Empty;
    public string Offerings { get; init; } = string.Empty;
    public string Individual { get; init; } = string.Empty;

    public override string ToString() => Description;
}
