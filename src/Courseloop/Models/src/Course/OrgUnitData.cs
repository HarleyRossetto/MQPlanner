namespace Courseloop.Models.Course;

using Courseloop.Models.Shared;
using Newtonsoft.Json;


public record OrgUnitData : IdentifiableRecord
{
    [JsonProperty("parent")]
    public LabelledValue Parent { get; set; }
    [JsonProperty("url")]
    public string Url { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
}
