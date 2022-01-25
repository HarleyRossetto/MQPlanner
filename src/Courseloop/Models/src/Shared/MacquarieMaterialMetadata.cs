namespace Courseloop.Models.Shared;

using System.Collections.Generic;
using Courseloop.Models.Json.Converters;
using Newtonsoft.Json;

public record MacquarieMaterialMetadata : IdentifiableRecord
{
    /*
        ImplementationYear

        Always 0
    */
    [JsonProperty("implementationYear")]
    public ushort ImplementationYear { get; set; }
    /*
        Status
    
        Always Approved

        TODO Make Status Enum.
    */
    [JsonProperty("status")]
    public LabelledValue Status { get; set; }

    /*
        AcademicOrganisation
    
        One of:
            Department of Linguistics
            Macquarie School of Education
            Macquarie University College
            Department of Actuarial Studies and Business Analytics
            School of Natural Sciences
            School of Engineering
            School of Mathematical and Physical Sciences
            Department of Management
            Owned at Faculty level
            School of Computing
            Macquarie Medical School
            Department of Health Sciences
            Macquarie University International College
            Department of Media, Communications, Creative Arts, Language and Literature
            Macquarie Law School
            Macquarie School of Social Sciences
            Department of Applied Finance
            Department of Marketing
            Department of Economics
            Department of Accounting and Corporate Governance
            Department of Security Studies and Criminology
            Department of History and Archaeology
            Department of Indigenous Studies
            Department of Philosophy
            Department of Ancient History
            Department of Chiropractic
            School of Psychological Sciences
            HDRO
            Department of Anthropology
            Australian Institute of Health Innovation
    */
    [JsonProperty("academic_org")]
    public KeyValueIdType AcademicOrganisation { get; set; }

    /*
        School
    
        One of:
            Faculty of Medicine, Health and Human Sciences
            Faculty of Arts
            Macquarie University College
            Macquarie Business School
            Faculty of Science and Engineering
            HDRO
    */
    [JsonProperty("school")]
    public KeyValueIdType School { get; set; }

    /*
        CreditPoints
    
        Either:
            0,
            5,
            10,
            20,
            30,
            40,
            80  
    */
    [JsonProperty("credit_points")]
    public ushort CreditPoints { get; set; }

    /*
        Type
    
        Either:
            ""
            "PACE"  
    */
    [JsonProperty("type")]
    public LabelledValue Type { get; set; }

    /*
        MetaDescription
    
        Unit description providing an overview of the subject.
    */
    [JsonProperty("description")]
    [JsonConverter(typeof(MacquarieHtmlStripperConverter))]
    public string MetaDescription { get; set; }

    /*
      SearchTitle

      Concatenation of Code and Subject title
  */
    [JsonProperty("search_title")]
    public string SearchTitle { get; set; }

    /*
        Code
    
        A Subjects' Unit Code. i.e. COMP1000 
    */
    [JsonProperty("code")]
    public string Code { get; set; }

    /*
        TItle
    
        The name of the unit.
    */
    [JsonProperty("title")]
    public string Title { get; set; }

    /*
        ContentType
    
        Always Unit (for units)
        Probable Course for courses.

        TODO Make ContentType Enum?
    */
    [JsonProperty("content_type")]
    public string ContentType { get; set; }

    /*
        CreditPointsHeader
    
        One of:
            10 credit points                
            20 credit points
            30 credit points
            40 credit points
            80 credit points
            5 credit points
            0 credit points
    */
    [JsonProperty("credit_points_header")]
    public string CreditPointsHeader { get; set; }

    /*
        Version
    
        Numerical version counting upwards.
        As on 17/12/2021 range is 1 to 6
    */
    [JsonProperty("version")]
    public string Version { get; set; }

    /*
        ClassName
    
        For units = "Unit"
    */
    [JsonProperty("class_name")]
    public string ClassName { get; set; }

    /*
        Overview
    
        Always empty i.e. ""
    */
    [JsonProperty("overview")]
    public string Overview { get; set; }

    /*
        AcademicItemType
    
        For units = "Unit"
    */
    [JsonProperty("academic_item_type")]
    public string AcademicItemType { get; set; }

    /*
        InherentRequirements
    
        Used occasionally
    */
    [JsonProperty("inherent_requirements")]
    public List<Requirement> InherentRequirements { get; set; }

    [JsonProperty("other_requirements")]
    public List<Requirement> OtherRequirements { get; set; }

    /*
        External Provider
    
        One of:
            "",
            null,
            Open Universities Australia,
            Coursera,
            Wuyagiba Study Hub,
            Wuyagiba Study Hub, NT
    */
    [JsonProperty("external_provider")]
    public string ExternalProvider { get; set; }

    [JsonProperty("links")]
    public List<string> Links { get; set; }

    /*
        PublishedInHandbook
    
        Always Yes
    */
    [JsonProperty("published_in_handbook")]
    public LabelledValue PublishedInHandbook { get; set; }
}
