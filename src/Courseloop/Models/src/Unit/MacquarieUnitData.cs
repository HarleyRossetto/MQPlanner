namespace Courseloop.Models.Unit;

using System;
using System.Collections.Generic;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit.Prerequisites;

using Newtonsoft.Json;


public record MacquarieUnitData : MacquarieMaterialMetadata
{
    /*
        Grading Schema

        "Graded" or "Pass/Fail"
    */
    [JsonProperty("grading_schema")]
    public LabelledValue GradingSchema { get; init; }

    /*
        StudyLevel

        Always "null"
    */
    [JsonProperty("study_level")]
    public LabelledValue StudyLevel { get; init; }

    /*
        QuoteEnrolmentRequirements

        Always empty i.e. ""
    */
    [JsonProperty("quota_enrolment_requirements")]
    public string QuoteEnrolmentRequirements { get; init; }

    /*
        StartDate

        Always null
    */
    [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? StartDate { get; init; }

    /*
        Exclusions

        Always empty i.e. ""
    */
    [JsonProperty("exclusions")]
    public string Exclusions { get; init; }

    /*
        Level

        1000,
        2000,
        3000,
        4000,
        5000,
        6000,
        7000,
        8000,
        0000
    */
    [JsonProperty("level")]
    public KeyValueIdType Level { get; init; }

    /*
        UACCode

        Always empty i.e. ""
    */
    [JsonProperty("uac_code")]
    public string UACCode { get; init; }

    /*
        SpecialRequirements

        Alaways empty i.e. ""
    */
    [JsonProperty("special_requirements")]
    public string SpecialRequirements { get; init; }

    [JsonProperty("special_unit_type")]
    public List<LabelledValue> SpecialUnitType { get; init; }

    /*
        VersionStatus

        Always "Approved"
    */
    [JsonProperty("version_status")]
    public LabelledValue VersionStatus { get; init; }

    /*
        EndDate

        Always null
    */
    [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EndDate { get; init; }

    /*
        LearningMaterials

        Treat as null.
    */
    [JsonProperty("learning_materials")]
    public string LearningMaterials { get; init; }

    /*
        SpecialTopic

        Always False
    */
    [JsonProperty("special_topic")]
    public bool SpecialTopic { get; init; }

    /*
        AscedBroad

        Always empty i.e. ""
    */
    [JsonProperty("asced_broad")]
    public KeyValueIdType AscedBroad { get; init; }

    /*
        PlacementProportion

        'Yes' or 'No'
    */
    [JsonProperty("placement_proportion")]
    public LabelledValue PlacementProportion { get; init; }

    /*
        MetaDescription

        Unique description of unit and content.
    */
    [JsonProperty("unit_description")]
    public List<string> Description { get; init; }

    [JsonProperty("unit_learning_outcomes")]
    public List<LearningOutcome> LearningOutcomes { get; init; }

    [JsonProperty("non_scheduled_learning_activities")]
    public List<LearningActivity> NonScheduledLearningActivities { get; init; }

    /*
        ScheduledLearningActivities

        Always null
    */
    [JsonProperty("scheduled_learning_activites")]
    public List<LearningActivity> ScheduledLearningActivites { get; init; }

    private List<EnrolmentRule> _enrolmentRules;
    [JsonProperty("enrolment_rules")]
    public List<EnrolmentRule> EnrolmentRules
    {
        get
        {
            return _enrolmentRules;
        }
        init
        {
            if (value is not null)
            {
                _enrolmentRules = value;

                //Original Implementation
                //PrerequisiteParserOld.ParsePrerequisites(value, Code);

                //Testing implementations
                //EnrolmentRules.ForEach(x => PrerequisiteParserOld.ParsePrerequisiteString(x.MetaDescription));
            }
        }
    }
    [JsonProperty("assessments")]
    public List<Assessment> Assessments { get; init; }

    [JsonProperty("requisites")]
    public List<Requisite> Requisites { get; init; }

    [JsonProperty("unit_offering")]
    public List<UnitOffering> Offering { get; init; }

    /*
        OfferingText 

        Semi-unique display text of when a unit is offered and what the attendance mode is.  
    */
    [JsonProperty("unit_offering_text")]
    public string OfferingText { get; init; }

    /*
        SubjectSearchTitle

        Concatenation of Code and Subject title
    */
    [JsonProperty("subject_search_title")]
    public string SubjectSearchTitle { get; init; }

    /*
        PublishedTuitionFees

        Always True
    */
    [JsonProperty("publish_tuition_fees")]
    public bool PublishTuitionFees { get; init; }

    /*
        D_gov_cohort_year

        Always False
    */
    [JsonProperty("d_gov_cohort_year")]
    public bool D_gov_cohort_year { get; init; }

    /*
        SMSStatus

        Always null
    */
    [JsonProperty("sms_status")]
    public LabelledValue SMSStatus { get; init; }

    /*
        SMSVersion

        Always empty i.e. ""
    */
    [JsonProperty("sms_version")]
    public string SMSVersion { get; init; }

    /*
        DurationFullTimeMax

        Always empty i.e. ""
    */
    [JsonProperty("duration_ft_max")]
    public string DurationFullTimeMax { get; init; }

    /*
        DurationPartTimeMax

        Always empty i.e. ""
    */
    [JsonProperty("duration_pt_max")]
    public string DurationPartTimeMax { get; init; }

    /*
        DurationPartTimeStandard

        Always empty i.e. ""
    */
    [JsonProperty("duration_pt_std")]
    public string DurationPartTimeStandard { get; init; }

    /*
        DurationPartTimeMinimum

        Always empty i.e. ""
    */
    [JsonProperty("duration_pt_min")]
    public string DurationPartTimeMinimum { get; init; }

    /*
        DurationPartTimePeriod

        Always empty i.e. ""
    */
    [JsonProperty("duration_pt_period")]
    public LabelledValue DurationPartTimePeriod { get; init; }

    [JsonProperty("parent_id")]
    public KeyValueIdType ParentId { get; init; }
}
