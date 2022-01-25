namespace Courseloop.Models.Unit.Prerequisites;

using Courseloop.Models.Json.Converters;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record EnrolmentRule : IdentifiableRecord
{
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; set; }
    [JsonProperty("type")]
    public LabelledValue Type { get; set; }
    [JsonProperty("order")]
    public ushort Order { get; init; }

    public override string ToString()
    {
        return Description;
    }
}
