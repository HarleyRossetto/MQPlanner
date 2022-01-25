using Courseloop.Models.Course;
using Planner.Models.Shared;

namespace Planner.Models.Course;

public record UnitGroupingContainerDto
{
    public string Title { get; init; } = string.Empty;
    public string Preface { get; init; } = string.Empty;
    public string DynamicQuery { get; init; } = string.Empty;
    public string Footnote { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string CreditPointsMax { get; init; } = string.Empty;
    public List<DynamicRelation>? DynamicRelationship { get; init; }
    public List<UnitGroupingContainerDto>? Container { get; init; }
    public List<AcademicItemDto>? Relationships { get; init; }
    public string ParentRecord { get; init; } = string.Empty;
}
