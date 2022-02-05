namespace Planner.Models.Shared;

public class LearningOutcomeDto
{
    public string? Description { get; init; } 
    public string? Code { get; init; } 
    public string? Number { get; init; }

    //public string Order { get; init; }

    public override string ToString() => Description ?? string.Empty;
}
