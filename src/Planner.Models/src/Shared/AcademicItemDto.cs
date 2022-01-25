namespace Planner.Models.Shared;

public record AcademicItemDto
{
    //Always null?
    //public KeyValueIdType InnerId { get; init; }
    public string Type { get; init; } = string.Empty;
    public string AbbreviationName { get; init; } = string.Empty;
    public string VersionName { get; init; } = string.Empty;
    public ushort CreditPoints { get; init; }
    public string AbbreviatedNameAndMajor { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string Code { get; init; } = string.Empty;
    public string Url { get; init; } = string.Empty;
    public string ParentRecord { get; init; } = string.Empty;
    public string Order { get; init; } = string.Empty;
}
