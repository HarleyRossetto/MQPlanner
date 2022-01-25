namespace Courseloop.Models.Course;
using System;
using System.Collections.Generic;
using Courseloop.Models.Shared;
using Newtonsoft.Json;

public record MacquarieCourseData : MacquarieMaterialMetadata
{
    [JsonProperty("aqf_level")]
    public LabelledValue AqfLevel { get; set; }
    [JsonProperty("accrediting_bodies")]
    public List<string> AccreditingBodies { get; set; }
    [JsonProperty("abbreviated_name_and_major")]
    public string AbbreviatedNameAndMajor { get; set; }
    [JsonProperty("course_code")]
    public string CourseCode { get; set; }
    [JsonProperty("abbreviated_name")]
    public string AbbreviatedName { get; set; }
    [JsonProperty("source")]
    public KeyValueIdType Source { get; set; }
    [JsonProperty("active")]
    public bool Active { get; set; }
    [JsonProperty("effective_date", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? EffectiveDate { get; set; }
    [JsonProperty("learning_and_teaching_methods")]
    public string LearningAndTeachingMethods { get; set; }
    [JsonProperty("overview_and_aims_of_the_course")]
    public string OverviewAndAimsOfTheCourse { get; set; }
    [JsonProperty("support_for_learning")]
    public string SupportForLearning { get; set; }
    [JsonProperty("graduate_destinations_and_employability")]
    public string GraduateDestinationsAndEmployability { get; set; }
    [JsonProperty("fitness_to_practice")]
    public string FitnessToPractice { get; set; }
    [JsonProperty("independent_research")]
    public string IndependentResearch { get; set; }
    [JsonProperty("justify_capstone_unit")]
    public string JustifyCapstoneUnit { get; set; }
    [JsonProperty("how_will_students_meet_clos_in_this_duration")]
    public string HowWillStudentsMeetClosInThisDuration { get; set; }
    [JsonProperty("what_is_the_internal_structure_of_course_majors")]
    public string WhatIsTheInternalStructureOfCourseMajors { get; set; }
    [JsonProperty("other_double_degree_considerations")]
    public string OtherDoubleDegreeConsiderations { get; set; }
    [JsonProperty("course_standards_and_quality")]
    public string CourseStandardsAndQuality { get; set; }
    [JsonProperty("exit")]
    public string Exit { get; set; }
    [JsonProperty("part_time")]
    public bool PartTime { get; set; }
    [JsonProperty("structure")]
    public string Structure { get; set; }
    [JsonProperty("no_enrolment")]
    public bool NoEnrolment { get; set; }
    [JsonProperty("publication_information")]
    public string PublicationInformation { get; set; }
    [JsonProperty("internship_placement")]
    public string InternshipPlacement { get; set; }
    [JsonProperty("specialisations")]
    public string Specialisations { get; set; }
    [JsonProperty("govt_special_course_type")]
    public LabelledValue GovtSpecialCourseType { get; set; }
    [JsonProperty("entry_list")]
    public List<string> EntryList { get; set; }
    [JsonProperty("entry_guarantee")]
    public bool EntryGuarantee { get; set; }
    [JsonProperty("police_check")]
    public bool PoliceCheck { get; set; }
    [JsonProperty("year_12_prerequisites")]
    public string Year12Prerequisites { get; set; }
    [JsonProperty("last_review_date")]
    public string LastReviewDate { get; set; }
    [JsonProperty("career_opportunities")]
    public string CareerOpportunities { get; set; }
    [JsonProperty("location")]
    public string Location { get; set; }
    [JsonProperty("course_value")]
    public KeyValueIdType CourseValue { get; set; }
    [JsonProperty("alternative_exits")]
    public string AlternativeExits { get; set; }
    [JsonProperty("progression")]
    public string Progression { get; set; }
    [JsonProperty("english_language")]
    public string EnglishLanguage { get; set; }
    [JsonProperty("ib_maths")]
    public string IbMaths { get; set; }
    [JsonProperty("requirements")]
    public string Requirements { get; set; }
    [JsonProperty("qualification_requirement")]
    public string QualificationRequirement { get; set; }
    [JsonProperty("articulation_arrangement")]
    public string ArticulationArrangement { get; set; }
    [JsonProperty("partner_faculty")]
    public LabelledValue PartnerFaculty { get; set; }
    [JsonProperty("full_time")]
    public bool FullTime { get; set; }
    [JsonProperty("qualifications")]
    public string Qualifications { get; set; }
    [JsonProperty("double_degrees")]
    public string DoubleDegrees { get; set; }
    [JsonProperty("international_students")]
    public bool InternationalStudents { get; set; }
    [JsonProperty("special_admission")]
    public string SpecialAdmission { get; set; }
    [JsonProperty("entry")]
    public string Entry { get; set; }
    [JsonProperty("atar")]
    public string Atar { get; set; }
    [JsonProperty("course_data_updated", NullValueHandling = NullValueHandling.Ignore)]
    public DateTime? CourseDataUpdated { get; set; }
    [JsonProperty("prior_learning_recognition")]
    public string PriorLearningRecognition { get; set; }
    [JsonProperty("vce_other")]
    public string VceOther { get; set; }
    [JsonProperty("awards_titles")]
    public string AwardsTitles { get; set; }
    [JsonProperty("on_campus")]
    public bool OnCampus { get; set; }
    [JsonProperty("research_areas")]
    public string ResearchAreas { get; set; }
    [JsonProperty("accrediation_start_date")]
    public string AccrediationStartDate { get; set; }
    [JsonProperty("particiption_enrolment")]
    public string ParticiptionEnrolment { get; set; }
    [JsonProperty("vce_english")]
    public string VceEnglish { get; set; }
    [JsonProperty("ib_other")]
    public string IbOther { get; set; }
    [JsonProperty("online")]
    public bool Online { get; set; }
    [JsonProperty("progress_to_masters")]
    public string ProgressToMasters { get; set; }
    [JsonProperty("additional_info")]
    public string AdditionalInfo { get; set; }
    [JsonProperty("criscos_disclaimer_applicable")]
    public bool CriscosDisclaimerApplicable { get; set; }
    [JsonProperty("other_description")]
    public string OtherDescription { get; set; }
    [JsonProperty("other")]
    public bool Other { get; set; }
    [JsonProperty("health_records_and_privacy")]
    public bool HealthRecordsAndPrivacy { get; set; }
    [JsonProperty("information_declaration")]
    public bool InformationDeclaration { get; set; }
    [JsonProperty("ahegs")]
    public string Ahegs { get; set; }
    [JsonProperty("criscos_status")]
    public LabelledValue CriscosStatus { get; set; }
    [JsonProperty("prohibited_employment_declaration")]
    public bool ProhibitedEmploymentDeclaration { get; set; }
    [JsonProperty("minimum_entry_requirements")]
    public string MinimumEntryRequirements { get; set; }
    [JsonProperty("accrediation_end_date")]
    public string EccrediationEndDate { get; set; }
    [JsonProperty("accrediation_end")]
    public string AccrediationEnd { get; set; }
    [JsonProperty("post_nominals")]
    public string PostNominals { get; set; }
    [JsonProperty("ib_english")]
    public string IbEnglish { get; set; }
    [JsonProperty("credit_arrangements")]
    public string CreditArrangements { get; set; }
    [JsonProperty("outcomes")]
    public string Outcomes { get; set; }
    [JsonProperty("major_minors")]
    public string MajorMinors { get; set; }
    [JsonProperty("vce_maths")]
    public string VceMaths { get; set; }
    [JsonProperty("degrees_awarded")]
    public string DegreesAwarded { get; set; }
    [JsonProperty("non_year_12_entry")]
    public string NonYear12Entry { get; set; }
    [JsonProperty("working_with_children_check")]
    public bool WorkingWithChildrenCheck { get; set; }
    [JsonProperty("entry_pathways_and_adjustment_factors_other_details")]
    public string EntryPathwaysAndAdjustmentFactorsOtherDetails { get; set; }
    [JsonProperty("entry_pathways_and_adjustment_factors")]
    public List<KeyValueIdType> EntryPathwaysAndAdjustmentFactors { get; set; }
    [JsonProperty("does_undergraduate_principle_26_3_apply")]
    public bool DoesUndergraduatePrinciple_26_3Apply { get; set; }
    [JsonProperty("formal_articulation_pathway_to_higher_award")]
    public bool FormalArticulationPathwayToHigherAward { get; set; }
    [JsonProperty("application_method_other_details")]
    public string ApplicationMethodOtherDetails { get; set; }
    [JsonProperty("ielts_overall_score")]
    public string IeltsOverallScore { get; set; }
    [JsonProperty("is_this_an_accelerated_course")]
    public string IsThisAnAcceleratedCourse { get; set; }
    [JsonProperty("how_does_this_course_deliver_a_capstone_experience")]
    public string HowDoesThisCourseDeliverACapstoneExperience { get; set; }
    [JsonProperty("hours_per_week")]
    public string HoursPerWeek { get; set; }
    [JsonProperty("exclusively_an_exit_award")]
    public LabelledValue ExclusivelyAnExitAward { get; set; }
    [JsonProperty("ielts_listening_score")]
    public string IeltsListeningScore { get; set; }
    [JsonProperty("admission_to_combined_double")]
    public string AdmissionToCombinedDouble { get; set; }
    [JsonProperty("ielts_speaking_score")]
    public string IELTS_speaking_score { get; set; }
    [JsonProperty("capstone_or_professional_practice")]
    public string CapstoneOrProfessionalPractice { get; set; }
    [JsonProperty("external_body")]
    public string ExternalBody { get; set; }
    [JsonProperty("other_provider_name")]
    public string OtherProviderName { get; set; }
    [JsonProperty("provider_name_and_supporting_documentation")]
    public string ProviderNameAndSupportingDocumentation { get; set; }
    [JsonProperty("arrangements")]
    public string Arrangements { get; set; }
    [JsonProperty("number_of_weeks")]
    public string NumberOfWeeks { get; set; }
    [JsonProperty("application_method")]
    public List<KeyValueIdType> ApplicationMethod { get; set; }
    [JsonProperty("delivery_with_third_party_provider")]
    public bool DeliveryWithThirdPartyProvider { get; set; }
    [JsonProperty("are_there_additional_admission_points")]
    public bool AreThereAdditionalAdmissionPoints { get; set; }
    [JsonProperty("volume_of_learning")]
    public LabelledValue VolumeOfLearning { get; set; }
    [JsonProperty("award_abbreviation")]
    public string AwardAbbreviation { get; set; }
    [JsonProperty("admission_requirements")]
    public string AdmissionRequirements { get; set; }
    [JsonProperty("any_double_degree_exclusions")]
    public bool AnyDoubleDegreeExclusions { get; set; }
    [JsonProperty("ielts_writing_score")]
    public string IeltsWritingScore { get; set; }
    [JsonProperty("ahegs_award_text")]
    public string AhegsAwardText { get; set; }
    [JsonProperty("work_based_training_component")]
    public bool WorkBasedTrainingComponent { get; set; }
    [JsonProperty("ielts_reading_score")]
    public string IeltsReadingScore { get; set; }
    [JsonProperty("wam_required_for_progression")]
    public string WamRequiredForProgression { get; set; }
    [JsonProperty("accrediation_text_for_ahegs")]
    public string AccrediationTextForAhegs { get; set; }
    [JsonProperty("provider_name")]
    public LabelledValue ProviderName { get; set; }
    [JsonProperty("assessment_regulations")]
    public string AssessmentRegulations { get; set; }
    [JsonProperty("accrediated_by_external_body")]
    public bool AccrediatedByExternalBody { get; set; }
    [JsonProperty("offered_by_an_external_provider")]
    public bool OfferedByAnExternalProvider { get; set; }
    [JsonProperty("assessment")]
    public string Assessment { get; set; }
    [JsonProperty("level2_org_unit_data")]
    public List<OrgUnitData> Level2OrgUnitData { get; set; }
    [JsonProperty("related_associated_items")]
    public List<string> RelatedAssociatedItems { get; set; }
    [JsonProperty("offering")]
    public List<Offering> Offering { get; set; }
    [JsonProperty("study_modes")]
    public List<string> StudyModes { get; set; }
    [JsonProperty("additional_admission_points")]
    public List<AdmissionRequirementPoint> AdditionalAdmissionPoints { get; set; }
    [JsonProperty("course_rules")]
    public List<string> CourseRules { get; set; }
    [JsonProperty("course_notes")]
    public List<CourseNote> CourseNotes { get; set; }
    [JsonProperty("learning_outcomes")]
    public List<LearningOutcome> LearningOutcomes { get; set; }
    [JsonProperty("higher_level_courses_that_students_may_exit_from")]
    public List<HigherLevelCoursesThatStudentsMayExitFrom> HigherLevelCoursesThatStudentsMayExitFrom { get; set; }
    [JsonProperty("level1_org_unit_data")]
    public List<OrgUnitData> Level1OrgUnitData { get; set; }
    [JsonProperty("articulations")]
    public List<Articulation> Articulations { get; set; }
    [JsonProperty("course_search_title")]
    public string CourseSearchTitle { get; set; }
    [JsonProperty("availableInDoubles")]
    public string AvailableInDoubles { get; set; }
    [JsonProperty("availableDoubles")]
    public string AvailableDoubles { get; set; }
    [JsonProperty("availableAOS")]
    public string AvailableAOS { get; set; }

    [JsonProperty("ext_id")]
    public string ExtId { get; set; }

    [JsonProperty("version_name")]
    public string VersionName { get; set; }

    [JsonProperty("fees")]
    public List<Fee> Fees { get; set; }

    [JsonProperty("course_duration_in_years")]
    public LabelledValue CourseDurationInYears { get; set; }

    [JsonProperty("maximum_duration")]
    public string MaximumDuration { get; set; }

    [JsonProperty("full_time_duration")]
    public string FullTimeDuration { get; set; }

    [JsonProperty("part_time_duration")]
    public string PartTimeDuration { get; set; }


    [JsonProperty("fees_description")]
    public string FeesDescription { get; set; }

    [JsonProperty("cricos_code")]
    public string CricosCode { get; set; }
}
