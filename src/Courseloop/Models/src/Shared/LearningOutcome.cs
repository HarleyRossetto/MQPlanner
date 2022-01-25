namespace Courseloop.Models.Shared;
using Newtonsoft.Json;


public record LearningOutcome : IdentifiableRecord
{

    [JsonProperty("description")]
    // [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; set; }
    [JsonProperty("code")]
    public string Code { get; set; }

    [JsonProperty("number")]
    public string Number { get; set; }

    [JsonProperty("order")]
    public string Order { get; set; }

    [JsonProperty("linking_id")]
    public string LinkingId { get; set; }

    [JsonProperty("lo_cl_id")]
    public string LO_CL_ID { get; set; }

    [JsonProperty("academic_item")]
    public KeyValueIdType AcademicItem { get; set; }

    public override string ToString()
    {
        return Description;
    }
}
