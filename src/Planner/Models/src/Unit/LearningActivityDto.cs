namespace Planner.Models.Unit;

public class LearningActivityDto
{
    public string? Description { get; init; } 
    public string? Activity { get; init; } 
    public string? Offerings { get; init; }

    public override string ToString() => Description ?? string.Empty;
}
