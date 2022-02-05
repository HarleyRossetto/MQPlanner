namespace Planner.Models.Unit;

public record UnitOfferingDto
{
    public string? Publish { get; init; } 
    public string? Name { get; init; } 
    public string? DisplayName { get; init; } 
    public string? TeachingPeriod { get; init; } 
    public string? AttendanceMode { get; init; } 
    public string? QuotaNumber { get; init; } 
    public string? StudyLevel { get; init; } 
    public string? AcademicItem { get; init; } 
    public string? ClarificationToAppearInHandbook { get; init; } 
    public string? SelfEnrol { get; init; } 
    public string? Order { get; init; } 
    public string? FeesCommonwealth { get; init; } 
    public string? FeesInternational { get; init; } 
    public string? CourseRestrictions { get; init; } 
    public string? QuotaLimit { get; init; } 
    public string? FeesDomestic { get; init; } 
    public string? Location { get; init; } 

    public override string ToString() => DisplayName ?? string.Empty;
}
