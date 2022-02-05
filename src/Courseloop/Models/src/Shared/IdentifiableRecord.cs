namespace Courseloop.Models.Shared;

using Newtonsoft.Json;

public record IdentifiableRecord
{

    [JsonProperty("cl_id")]
    public string CL_ID { get; init; } = string.Empty;
}
