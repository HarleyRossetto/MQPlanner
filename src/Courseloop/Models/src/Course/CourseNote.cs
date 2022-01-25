namespace Courseloop.Models.Course;

using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record CourseNote : IdentifiableRecord
{
    [JsonProperty("note")]
    public string Note { get; set; }
    [JsonProperty("type")]
    public LabelledValue Type { get; set; }
    [JsonProperty("display_value")]
    public string DisplayValue { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }
}
