using Courseloop.Models.Shared;

namespace Planner.Models.Shared;

public class NewBaseType {
    public List<Requirement>? InherentRequirements { get; init; }
}

public class MaterialMetadataDto : NewBaseType {
    public ushort ImplementationYear { get; init; }
    public string Status { get; init; } = string.Empty;
    //TODO Make AcademicOrganisation enum? Potentially translate any ID's to string names.
    public string AcademicOrganisation { get; init; } = string.Empty;
    public string School { get; init; } = string.Empty;
    public ushort CreditPoints { get; init; } = 0;
    public string Type { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string SearchTitle { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    public string Title { get; init; } = string.Empty;
    public string ContentType { get; init; } = string.Empty;
    public string CreditPointsHeader { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string ClassName { get; init; } = string.Empty;
    public string Overview { get; init; } = string.Empty;
    public string AcademicItemType { get; init; } = string.Empty;
    public List<Requirement>? OtherRequirements { get; init; }
    public string ExternalProvider { get; init; } = string.Empty;
    public List<string>? Links { get; init; }
    public LabelledValue? PublishedInHandbook { get; init; }
}
