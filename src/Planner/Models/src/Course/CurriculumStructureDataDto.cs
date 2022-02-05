namespace Planner.Models.Course;

public record CurriculumStructureDataDto
{
    public short CreditPoints { get; init; }
    public DateTime? EffectiveDate { get; init; }
    public List<UnitGroupingContainerDto>? Container { get; init; }
    public string? Name { get; init; }
}