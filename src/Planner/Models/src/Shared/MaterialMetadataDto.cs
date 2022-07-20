using Courseloop.Models.Shared;

namespace Planner.Models.Shared;

public record MaterialMetadataDto {
    public List<Requirement>? InherentRequirements { get; init; }
    public ushort? ImplementationYear { get; init; }
    public string? Status { get; init; }
    //TODO Make AcademicOrganisation enum? Potentially translate any ID's to string names.
    public string? AcademicOrganisation { get; init; }
    public string? School { get; init; }
    public ushort? CreditPoints { get; init; }
    public string? Type { get; init; }
    public string? Description { get; init; }
    public string? SearchTitle { get; init; }
    public string? Code { get; init; }
    public string? Title { get; init; }
    public string? ContentType { get; init; }
    public string? CreditPointsHeader { get; init; }
    public string? Version { get; init; }
    public string? ClassName { get; init; }
    public string? Overview { get; init; }
    public string? AcademicItemType { get; init; }
    public List<Requirement>? OtherRequirements { get; init; }
    public string? ExternalProvider { get; init; }
    public List<string>? Links { get; init; }
    public LabelledValue? PublishedInHandbook { get; init; }
}
