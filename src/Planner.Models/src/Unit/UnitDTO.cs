namespace Planner.Models.Unit;
using Planner.Models.Shared;

public record UnitDto : MetadataDto
{
    public UnitDataDto Data { get; init; } = null!;
    public ushort CreditPoints { get; init; }
    public string Description { get; init; } = string.Empty;
    public string Level { get; init; } = string.Empty;
    public ushort PublishedInHandbook { get; init; }
    public string LevelDisplay { get; init; } = string.Empty;
    public DateTime? EffectiveDate { get; init; }
    public string Status { get; init; } = string.Empty;
    public string Version { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;

    public override string ToString() => $"{Data.Code} {ImplementationYear}";

    public string FullUrl { get => $"{HostName}{UrlMapForContent}"; }
}
