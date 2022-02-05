namespace Planner.Models.Shared;

public record AcademicItemDto
{
    //Always null?
    //public KeyValueIdType InnerId { get; init; }
    public string? Type { get; init; } 
    public string? AbbreviationName { get; init; } 
    public string? VersionName { get; init; } 
    public ushort CreditPoints { get; init; }
    public string? AbbreviatedNameAndMajor { get; init; } 
    public string? Name { get; init; } 
    public string? Code { get; init; } 
    public string? Url { get; init; } 
    public string? ParentRecord { get; init; } 
    public string? Order { get; init; } 
}
