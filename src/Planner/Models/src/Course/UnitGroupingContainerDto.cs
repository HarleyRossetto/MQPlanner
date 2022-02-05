using Courseloop.Models.Course;
using Planner.Models.Shared;

namespace Planner.Models.Course;

public record UnitGroupingContainerDto
{
    public string? Title { get; init; } 
    public string? Preface { get; init; } 
    public string? DynamicQuery { get; init; } 
    public string? Footnote { get; init; } 
    public string? Description { get; init; } 
    public string? CreditPointsMax { get; init; } 
    public List<DynamicRelation>? DynamicRelationship { get; init; }
    public List<UnitGroupingContainerDto>? Container { get; init; }
    public List<AcademicItemDto>? Relationships { get; init; }
    public string? ParentRecord { get; init; } 
}
