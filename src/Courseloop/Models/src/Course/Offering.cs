namespace Courseloop.Models.Course;

using System;
using System.Collections.Generic;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record Offering : IdentifiableRecord
{
    [JsonProperty("mode")]
    public LabelledValue Mode { get; set; }
    [JsonProperty("admission_calendar")]
    public LabelledValue AdmissionCalendar { get; set; }
    [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? StartDate { get; set; }
    [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EndDate { get; set; }
    [JsonProperty("comments")]
    public string Comments { get; set; }
    [JsonProperty("language_of_instruction")]
    public LabelledValue LanguageOfInstruction;
    [JsonProperty("ext_id")]
    public string ExtId { get; set; }
    [JsonProperty("publish")]
    public bool Publish { get; set; }
    [JsonProperty("status")]
    public LabelledValue Status { get; set; }
    [JsonProperty("offered")]
    public bool Offered { get; set; }
    [JsonProperty("display_name")]
    public string DisplayName { get; set; }
    [JsonProperty("location")]
    public LabelledValue Location { get; set; }
    [JsonProperty("name")]
    public string Name { get; set; }
    [JsonProperty("attendance_type")]
    public List<string> AttendanceType { get; set; }
    [JsonProperty("academic_item")]
    public LabelledValue AcademicItem { get; set; }
    [JsonProperty("year")]
    public string Year { get; set; }
    [JsonProperty("entry_point")]
    public bool EntryPoint { get; set; }

    [JsonProperty("linking_id")]
    public string LinkingId { get; set; }

    [JsonProperty("clarification_to_appear_in_handbook")]
    public string ClarificationToAppearInHandbook { get; set; }

    [JsonProperty("order")]
    public string Order { get; set; }

}
