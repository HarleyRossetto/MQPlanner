namespace Planner.Models.Course;

public record CourseNoteDto
{
    public string Note { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public string DisplayValue { get; init; } = string.Empty;
    public string Number { get; init; } = string.Empty;
}