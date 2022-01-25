using Planner.Models.Shared;

namespace Planner.Models.Unit;

public record RequisiteContainerDto
{
    public string Connector { get; init; } = string.Empty;
    public List<RequisiteContainerDto>? Containers { get; init; }
    public List<AcademicItemDto>? Relationships { get; init; }
}
