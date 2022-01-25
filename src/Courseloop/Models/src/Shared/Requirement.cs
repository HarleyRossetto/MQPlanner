namespace Courseloop.Models.Shared;

using System.Collections.Generic;
using Newtonsoft.Json;

public class Requirement
{
    /*
        Domain

        One of:
            Behaviour
            Physical capability
            Communication
            Cognition

            Working with children check
            Fitness to practice
            Other requirements
    */
    [JsonProperty("domain")]
    public string Domain { get; set; }


    [JsonProperty("rules")]
    public List<Rule> Rules { get; set; }
}
