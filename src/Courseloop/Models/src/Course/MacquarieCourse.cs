namespace Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Newtonsoft.Json;
using Courseloop.Models.Json.Converters;

public class MacquarieCourse : MacquarieMetadata
{
    [JsonProperty("data")]
    [JsonConverter(typeof(MacquarieEmbeddedJsonConverter<MacquarieCourseData>))]
    public MacquarieCourseData CourseData { get; set; }
    [JsonProperty("CurriculumStructure")]
    [JsonConverter(typeof(MacquarieEmbeddedJsonConverter<MacquarieCurriculumStructureData>))]
    public MacquarieCurriculumStructureData CurriculumData { get; set; }
    [JsonProperty("urlYear")]
    public string UrlYear { get; set; }
    [JsonProperty("generic")]
    public string Generic { get; set; }
    [JsonProperty("urlMap")]
    public string UrlMap { get; set; }


    [JsonProperty("modUserName")]
    public string ModUserName { get; set; }
}
