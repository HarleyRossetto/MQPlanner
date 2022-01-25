namespace Courseloop.Models.Unit;

using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record UnitOffering : IdentifiableRecord
{
    [JsonProperty("publish")]
    public string Publish { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("display_name")]
    public string DisplayName { get; set; }
    [JsonProperty("teaching_period")]
    public KeyValueIdType TeachingPeriod { get; set; }
    [JsonProperty("attendance_mode")]
    public KeyValueIdType AttendanceMode { get; set; }
    [JsonProperty("quota_number")]
    public string QuotaNumber { get; set; }
    [JsonProperty("study_level")]
    public LabelledValue StudyLevel { get; set; }
    [JsonProperty("academic_item")]
    public KeyValueIdType AcademicItem { get; set; }

    [JsonProperty("clarification_to_appear_in_handbook")]
    public string ClarificationToAppearInHandbook { get; set; }
    [JsonProperty("self_enrol")]
    public string SelfEnrol { get; set; }
    [JsonProperty("order")]
    public string Order { get; set; }

    [JsonProperty("fees_commonwealth")]
    public string FeesCommonwealth { get; set; }

    [JsonProperty("fees_international")]
    public string FeesInternational { get; set; }

    [JsonProperty("course_restrictions")]
    public string CourseRestrictions { get; set; }

    [JsonProperty("quota_limit")]
    public string QuotaLimit { get; set; }

    [JsonProperty("fees_domestic")]
    public string FeesDomestic { get; set; }

    [JsonProperty("location")]
    public LabelledValue Location { get; set; }

    public override string ToString()
    {
        return DisplayName;
    }
}
