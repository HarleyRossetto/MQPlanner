namespace Planner.Models.Unit;

public record UnitOfferingDto
{
    public string Publish { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public string TeachingPeriod { get; init; } = string.Empty;
    public string AttendanceMode { get; init; } = string.Empty;
    public string QuotaNumber { get; init; } = string.Empty;
    public string StudyLevel { get; init; } = string.Empty;
    public string AcademicItem { get; init; } = string.Empty;
    public string ClarificationToAppearInHandbook { get; init; } = string.Empty;
    public string SelfEnrol { get; init; } = string.Empty;
    public string Order { get; init; } = string.Empty;
    public string FeesCommonwealth { get; init; } = string.Empty;
    public string FeesInternational { get; init; } = string.Empty;
    public string CourseRestrictions { get; init; } = string.Empty;
    public string QuotaLimit { get; init; } = string.Empty;
    public string FeesDomestic { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;

    public override string ToString() => DisplayName;
}
