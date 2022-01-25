namespace Planner.Models.Unit;

public record RequisiteDto
{
    public string AcademicItemCode { get; init; } = string.Empty;

    public string Description { get; init; } = string.Empty;

    public string Type { get; init; } = string.Empty;

    public string AcademicItemVersionNumber { get; init; } = string.Empty;

    public List<RequisiteContainerDto>? Requisites { get; init; }

    public string Order { get; init; } = string.Empty;
}
