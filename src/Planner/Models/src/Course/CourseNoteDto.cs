namespace Planner.Models.Course;

public record CourseNoteDto
{
    public string? Note { get; init; }
    public string? Type { get; init; }
    public string? DisplayValue { get; init; }
    public string? Number { get; init; }
}