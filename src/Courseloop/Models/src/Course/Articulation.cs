namespace Courseloop.Models.Course;

using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record Articulation : IdentifiableRecord
{
    [JsonProperty("course")]
    public string Course { get; set; }
    [JsonProperty("articulation_conditions")]
    public string ArticulationConditions { get; set; }
    [JsonProperty("details")]
    public string Details { get; set; }
    [JsonProperty("credit_transfer_arrangements")]
    public LabelledValue CreditTransferArrangements { get; set; }
}
