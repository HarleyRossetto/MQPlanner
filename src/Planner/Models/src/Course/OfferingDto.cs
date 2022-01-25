using Courseloop.Models.Shared;

namespace Planner.Models.Course;

public record OfferingDto
{
    public string Mode { get; init; } = string.Empty;
    public string AdmissionCalendar { get; init; } = string.Empty;
    public DateTime? StartDate { get; init; }
    public DateTime? EndDate { get; init; }
    public string Comments { get; init; } = string.Empty;
    public LabelledValue? LanguageOfInstruction;
    public string ExtId { get; init; } = string.Empty;
    public bool Publish { get; init; }
    public string Status { get; init; } = string.Empty;
    public bool Offered { get; init; }
    public string DisplayName { get; init; } = string.Empty;
    public string Location { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public List<string>? AttendanceType { get; init; }
    //public LabelledValue AcademicItem { get; init; }
    public ushort Year { get; init; }
    public bool EntryPoint { get; init; }
    public string ClarificationToAppearInHandbook { get; init; } = string.Empty;
    public string Order { get; init; } = string.Empty;
}
