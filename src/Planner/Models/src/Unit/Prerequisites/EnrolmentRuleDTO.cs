namespace Planner.Models.Unit.Prerequisites;

public record EnrolmentRuleDto
{
    public string? Description { get; init; } 
    public string? Type { get; init; } 
    public ushort? Order { get; init; }

    public override string ToString() => Description ?? string.Empty;
}
