namespace Planner.Models.Unit;

public record RequisiteDto
{
    public string? AcademicItemCode { get; init; } 

    public string? Description { get; init; } 

    public string? Type { get; init; } 

    public string? AcademicItemVersionNumber { get; init; } 

    public List<RequisiteContainerDto>? Requisites { get; init; }

    public string? Order { get; init; } 
}
