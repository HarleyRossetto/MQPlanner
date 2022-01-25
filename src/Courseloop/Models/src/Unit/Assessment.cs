namespace Courseloop.Models.Unit;
using Newtonsoft.Json;
using Courseloop.Models.Shared;
using Courseloop.Models.Json.Converters;

public record Assessment : IdentifiableRecord
{
    [JsonProperty("assessment_title")]
    public string AssessmentTitle { get; init; }
    [JsonProperty("type")]
    public LabelledValue Type { get; init; }
    [JsonProperty("weight")]
    public string Weight { get; init; }
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; init; }
    [JsonProperty("applies_to_all_offerings")]
    public string AppliesToAllOfferings { get; init; }
    [JsonProperty("hurdle_task")]
    public string HurdleTask { get; init; }
    [JsonProperty("offerings")]
    public string Offerings { get; init; }
    [JsonProperty("individual")]
    public LabelledValue Individual { get; init; }

    public override string ToString()
    {
        return Description;
    }
}
