namespace Planner.Models.Unit.Prerequisites;

public record EnrolmentRuleDto
{
    public string Description { get; init; } = string.Empty;
    public string Type { get; init; } = string.Empty;
    public ushort Order { get; init; } = 0;

    public override string ToString() => Description;
}
