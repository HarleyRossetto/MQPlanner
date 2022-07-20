namespace Courseloop.Models.Shared;

using Newtonsoft.Json;


public record LabelledValue
{
    [JsonProperty("label")]
    public string Label { get; set; } = String.Empty;
    [JsonProperty("value")]
    public string Value { get; set; } = String.Empty;

    public override string ToString()
    {
        return Label;
    }
}
