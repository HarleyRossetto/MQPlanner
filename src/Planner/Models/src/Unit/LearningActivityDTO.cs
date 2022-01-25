namespace Planner.Models.Unit;

public class LearningActivityDto
{
    public string Description { get; init; } = string.Empty;
    public string Activity { get; init; } = string.Empty;
    public string Offerings { get; init; } = string.Empty;

    public override string ToString() {
        return Description;
    }
}
