namespace Courseloop.Models.Unit;

using Courseloop.Models.Json.Converters;
using Courseloop.Models.Shared;
using Newtonsoft.Json;


public record LearningActivity : IdentifiableRecord
{
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; init; }
    [JsonProperty("activity")]
    public LabelledValue Activity { get; init; }
    [JsonProperty("offerings")]
    public string Offerings { get; init; }

    public override string ToString()
    {
        return Description;
    }
}

public record ScheduledLearningActivity : LearningActivity { }
public record NonScheduledLearningActivity : LearningActivity { }
