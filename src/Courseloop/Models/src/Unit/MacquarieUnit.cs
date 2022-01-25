namespace Courseloop.Models.Unit;

using System;
using Courseloop.Models.Json.Converters;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public class MacquarieUnit : MacquarieMetadata
{
    [JsonProperty("data")]
    [JsonConverter(typeof(MacquarieEmbeddedJsonConverter<MacquarieUnitData>))]
    public MacquarieUnitData Data { get; set; }
    /*
        CreditPoints

        Appears as:
            "0": 15,
            "5": 33,
            "10": 2308,
            "20": 24,
            "30": 8,
            "40": 4,
            "80": 40
    */
    [JsonProperty("creditPoints")]
    public ushort CreditPoints { get; set; }
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; set; }
    /*
        Level

        Appears as:
            "1000": 275,
            "2000": 379,
            "3000": 448,
            "4000": 100,
            "5000": 40,
            "6000": 100,
            "7000": 193,
            "8000": 888,
            "0000": 9
    */
    [JsonProperty("level")]
    public string Level { get; set; }
    /*
        PublishedInHandbook

        Always appears as '1'
    */
    [JsonProperty("publishedInHandbook")]
    public ushort PublishedInHandbook { get; set; }
    [JsonProperty("levelDisplay")]
    public string LevelDisplay { get; set; }
    [JsonProperty("effectiveDate", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EffectiveDate { get; set; }
    /*
        Status

        Always appears as "Active"
    */
    [JsonProperty("status")]
    public string Status { get; set; }

    public override string ToString() => $"{Data.Code} {ImplementationYear}";

    [JsonProperty("sysId")]
    public string SysId { get; set; }
    [JsonProperty("location")]
    public string Location { get; set; }
    [JsonProperty("version")]
    public string Version { get; set; }
    [JsonProperty("teachingPeriod")]
    public string TeachingPeriod { get; set; }
    /*
        Active

        Either 0 or 1. (no and yes/false and true)
    */
    [JsonProperty("active")]
    public string Active { get; set; }
    /*
        Type

        Either "pace" or "non_pace"
    */
    [JsonProperty("type")]
    public string Type { get; set; }
    /*
        BaseType

        Always 'CONTENT'
    */
    [JsonProperty("baseType")]
    public string BaseType { get; set; }
    [JsonProperty("mode")]
    public string Mode { get; set; }
    [JsonProperty("academicOrg")]
    public string AcademicOrg { get; set; }
}
