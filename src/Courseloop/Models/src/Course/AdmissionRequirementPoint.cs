namespace Courseloop.Models.Course;

using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record AdmissionRequirementPoint : IdentifiableRecord
{
    [JsonProperty("admission_requirement")]
    public string AdmissionRequirement { get; set; } = String.Empty;
    [JsonProperty("volume_of_learning")]
    public LabelledValue VolumeOfLearning { get; set; } = new();
    [JsonProperty("credit_points")]
    public uint CreditPoints { get; set; }
    [JsonProperty("structure_zones")]
    public List<KeyValueIdType> StructureZones { get; set; } = new();
}
