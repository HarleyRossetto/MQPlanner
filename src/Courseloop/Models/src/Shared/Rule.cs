namespace Courseloop.Models.Shared;

using System.Collections.Generic;
using Courseloop.Models.Json.Converters;
using Newtonsoft.Json;


public class Rule
{
    /*
        MetaDescription
    
        MetaDescription of said Rule.
    */
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; set; }

    /*
        Domain
    
        One of:
            Behaviour
            Physical Capability
            Communication
            Cognition  

            Working with children check
            Fitness to practice
            Other requirements
    */
    [JsonProperty("domain")]
    public LabelledValue Domain { get; set; }

    /*
        Links
    
        Appears to always be empty.
    */
    [JsonProperty("links")]
    public List<string> Links { get; set; }
}
