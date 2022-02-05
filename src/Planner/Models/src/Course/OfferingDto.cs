using Courseloop.Models.Shared;

namespace Planner.Models.Course;

public record OfferingDto
{
    public string? Mode { get; init; }
    public string? AdmissionCalendar { get; init; }
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string? Comments { get; init; }
    public LabelledValue? LanguageOfInstruction;
    public string? ExtId { get; init; }
    public bool Publish { get; init; }
    public string? Status { get; init; }
    public bool Offered { get; init; }
    public string? DisplayName { get; init; }
    public string? Location { get; init; }
    public string? Name { get; init; }
    public List<string?>? AttendanceType { get; init; }
    //public LabelledValue AcademicItem { get; init; }
    public string? Year { get; init; }
    public bool EntryPoint { get; init; }
    public string? ClarificationToAppearInHandbook { get; init; }
    public string? Order { get; init; }
}
