namespace Courseloop.Models.Shared;

using System;
using Newtonsoft.Json;

public record AcademicItem : IdentifiableRecord
{
    [JsonProperty("academic_item")]
    public KeyValueIdType InnerId { get; init; }
    [JsonProperty("academic_item_type")]
    public LabelledValue Type { get; init; }
    [JsonProperty("abbr_name")]
    public string AbbreviationName { get; init; }
    [JsonProperty("academic_item_version_name")]
    public string VersionName { get; init; }
    [JsonProperty("academic_item_credit_points")]
    public string CreditPoints { get; init; }
    [JsonProperty("abbreviated_name_and_major")]
    public string AbbreviatedNameAndMajor { get; init; }
    [JsonProperty("academic_item_name")]
    public string Name { get; init; }
    [JsonProperty("academic_item_code")]
    public string Code { get; init; }
    [JsonProperty("academic_item_url")]
    public string Url { get; init; }

    [JsonProperty("parent_record")]
    public KeyValueIdType ParentRecord { get; init; }

    [JsonProperty("order")]
    public string Order { get; init; }
}
