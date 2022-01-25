namespace Courseloop.Models.Unit.Prerequisites;

using System;
using System.Collections.Generic;
using Courseloop.Models.Json.Converters;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public class Requisite
{
    /*
        AcademicItemCode
    
        THe name of the associated unit.
    */
    [JsonProperty("academic_item_code")]
    public string AcademicItemCode { get; init; }

    /*
        Active
    
        true or false.
    */
    [JsonProperty("active")]
    public bool Active { get; init; }

    /*
        Description
    
        Empty?
    */
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string Description { get; init; }

    /*
        RequisiteType
    
        NCCW/anti_corequisite
    */
    [JsonProperty("requisite_type")]
    public LabelledValue RequisiteType { get; init; }

    /*
        AcademicItemVersionNumber
    
        Follows "yyyy.xx" format
    */
    [JsonProperty("academic_item_version_number")]
    public string AcademicItemVersionNumber { get; init; }

    /*
        StartDate
    
        Always null.
    */
    [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? StartDate { get; init; }

    /*
        EndDate
    
        Always null
    */
    [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EndDate { get; init; }

    /*
        Requisites
    
        List of requisites?
    */
    [JsonProperty("containers")]
    public List<ContainerRequisiteTemporaryName> Requisites { get; init; }

    /*
        Order
    
        
    */
    [JsonProperty("order")]
    public string Order { get; init; }

    /*
        CL_ID
    
        Unique Identifier
    */
    [JsonProperty("cl_id")]
    public KeyValueIdType CL_ID { get; init; }

    /*
        RequisiteClId
    
        Requisite list identifier
    */
    [JsonProperty("requisite_cl_id")]
    public string RequisiteClId { get; init; }
}
