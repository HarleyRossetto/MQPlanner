namespace Courseloop.Models.Shared;
using Newtonsoft.Json;

public record KeyValueIdType : IdentifiableRecord
{

    [JsonProperty("value")]
    public string Value { get; set; }

    [JsonProperty("key")]
    public string Key { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    public override string ToString()
    {
        return Value;
    }
}
