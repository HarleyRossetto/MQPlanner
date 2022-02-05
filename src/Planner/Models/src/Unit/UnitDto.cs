namespace Planner.Models.Unit;
using Planner.Models.Shared;

public record UnitDto : MetadataDto
{
    public UnitDataDto Data { get; init; } = null!;
    public ushort CreditPoints { get; init; }
    public string? Description { get; init; } 
    public string? Level { get; init; } 
    public ushort PublishedInHandbook { get; init; }
    public string? LevelDisplay { get; init; } 
    public DateTime? EffectiveDate { get; init; }
    public string? Status { get; init; } 
    public string? Version { get; init; } 
    public string? Type { get; init; } 

    public override string ToString() => $"{Data.Code} {ImplementationYear}";

    public string? FullUrl { get => $"{HostName}{UrlMapForContent}"; }
}
