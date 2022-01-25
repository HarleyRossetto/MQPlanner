namespace Courseloop.Models.Course;
using System;
using System.Collections.Generic;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record MacquarieCurriculumStructureData //: IdentifiableRecord
{
    [JsonProperty("credit_points")]
    public short CreditPoints { get; set; }
    [JsonProperty("effective_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EffectiveDate { get; set; }
    [JsonProperty("container")]
    public List<UnitGroupingContainer> Container { get; set; }


    [JsonProperty("ai_to_cs_cl_id")]
    public string AI_TO_CS_CL_ID { get; set; }

    [JsonProperty("cl_id")]
    public KeyValueIdType CL_ID { get; set; }

    [JsonProperty("curriculum_structure")]
    public KeyValueIdType CurriculumStructure { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("parent_id")]
    public KeyValueIdType ParentId { get; set; }

    [JsonProperty("parent_table")]
    public string ParentTable { get; set; }

    [JsonProperty("pe_remote_id")]
    public string PeRemoteId { get; set; }

    [JsonProperty("source")]
    public KeyValueIdType Source { get; set; }
}
