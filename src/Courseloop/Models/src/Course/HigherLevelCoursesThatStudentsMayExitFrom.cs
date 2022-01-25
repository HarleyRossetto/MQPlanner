namespace Courseloop.Models.Course;

using Courseloop.Models.Shared;
using Newtonsoft.Json;


public record HigherLevelCoursesThatStudentsMayExitFrom : IdentifiableRecord
{
    [JsonProperty("code")]
    public KeyValueIdType Code { get; set; }
    [JsonProperty("status")]
    public string Status { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
