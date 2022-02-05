namespace Planner.Models.Course;

public record AdmissionRequirementPointDto
{
    public string? AdmissionRequirement { get; init; }
    public string? VolumeOfLearning { get; init; }
    public uint? CreditPoints { get; init; }
    public List<string>? StructureZones { get; init; }
}
