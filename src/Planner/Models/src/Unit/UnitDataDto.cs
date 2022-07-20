using Planner.Models.Shared;
using Planner.Models.Unit.Prerequisites;

namespace Planner.Models.Unit;

public record UnitDataDto : MaterialMetadataDto
{
    public string? GradingSchema { get; init; }
    //public string StudyLevel { get; init; }
    //public string QuoteEnrolmentRequirements { get; init; }
    //public DateTime? StartDate { get; init; }
    //public string Exclusions { get; init; }
    public string? Level { get; init; }
    //public string UACCode { get; init; }
    //public string SpecialRequirements { get; init; }
    public List<string>? SpecialUnitType { get; init; }
    //public string VersionStatus { get; init; }
    //public DateTime? EndDate { get; init; }
    //public string LearningMaterials { get; init; }
    //public bool SpecialTopic { get; init; }
    //public string AscedBroad { get; init; }
    public string? PlacementProportion { get; init; }
    /// <summary>
    /// I believe Description in this context is unused.
    /// </summary>
    public List<string>? Description { get; init; }
    public List<LearningOutcomeDto>? LearningOutcomes { get; init; }
    public List<LearningActivityDto>? NonScheduledLearningActivities { get; init; }
    //public List<LearningActivityDto> ScheduledLearningActivites { get; init; }
    public List<EnrolmentRuleDto>? EnrolmentRules { get; init; }
    public List<AssessmentDto>? Assessments { get; init; }
    public List<RequisiteDto>? Requisites { get; init; }
    public List<UnitOfferingDto>? Offering { get; init; }
    public string? OfferingText { get; init; } 
    public string? SubjectSearchTitle { get; init; } 
    //public bool PublishTuitionFees { get; init; }
    //public bool D_gov_cohort_year { get; init; }
    //public string DurationFullTimeMax { get; init; }
    //public string DurationPartTimeMax { get; init; }
    //public string DurationPartTimeStandard { get; init; }
    //public string DurationPartTimeMinimum { get; init; }
    //public string DurationPartTimePeriod { get; init; }
}
