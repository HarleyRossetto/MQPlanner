using Courseloop.Models.Shared;

namespace Planner.Models.Course;

public record FeeDto
{
    public string? FeePerCreditPoint { get; init; }
    public string? FeeNote { get; init; }
    public string? OtherFeeType { get; init; }
    public List<KeyValueIdType>? Intakes { get; init; }
    public bool AppliesToAllIntakes { get; init; }
    public string? EstimatedAnnualFee { get; init; }
    public string? FeeType { get; init; }
}
