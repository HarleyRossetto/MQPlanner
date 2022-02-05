using Courseloop.Models.Course;
using Planner.Models.Shared;

namespace Planner.Models.Course;

public record CourseDataDto : MaterialMetadataDto
{
    public string? AqfLevel { get; init; }
    public List<string>? AccreditingBodies { get; init; }
    public string? AbbreviatedNameAndMajor { get; init; }
    public string? CourseCode { get; init; }
    public string? AbbreviatedName { get; init; }
    //public KeyValueIdType Source { get; init; }
    public bool Active { get; init; }
    public DateTime? EffectiveDate { get; init; }
    public string? LearningAndTeachingMethods { get; init; }
    public string? OverviewAndAimsOfTheCourse { get; init; }
    public string? SupportForLearning { get; init; }
    public string? GraduateDestinationsAndEmployability { get; init; }
    public string? FitnessToPractice { get; init; }
    public string? IndependentResearch { get; init; }
    public string? JustifyCapstoneUnit { get; init; }
    public string? HowWillStudentsMeetClosInThisDuration { get; init; }
    public string? WhatIsTheInternalStructureOfCourseMajors { get; init; }
    public string? OtherDoubleDegreeConsiderations { get; init; }
    public string? CourseStandardsAndQuality { get; init; }
    public string? Exit { get; init; }
    public bool PartTime { get; init; }
    public string? Structure { get; init; }
    public bool NoEnrolment { get; init; }
    public string? PublicationInformation { get; init; }
    public string? InternshipPlacement { get; init; }
    public string? Specialisations { get; init; }
    public string? GovtSpecialCourseType { get; init; }
    public List<string?>? EntryList { get; init; }
    public bool EntryGuarantee { get; init; }
    public bool PoliceCheck { get; init; }
    public string? Year12Prerequisites { get; init; }
    public string? LastReviewDate { get; init; }
    public string? CareerOpportunities { get; init; }
    public string? Location { get; init; }
    public string? CourseValue { get; init; }
    public string? AlternativeExits { get; init; }
    public string? Progression { get; init; }
    public string? EnglishLanguage { get; init; }
    public string? IbMaths { get; init; }
    public string? Requirements { get; init; }
    public string? QualificationRequirement { get; init; }
    public string? ArticulationArrangement { get; init; }
    public string? PartnerFaculty { get; init; }
    public bool FullTime { get; init; }
    public string? Qualifications { get; init; }
    public string? DoubleDegrees { get; init; }
    public bool InternationalStudents { get; init; }
    public string? SpecialAdmission { get; init; }
    public string? Entry { get; init; }
    public string? Atar { get; init; }
    public DateTime? CourseDataUpdated { get; init; }
    public string? PriorLearningRecognition { get; init; }
    public string? VceOther { get; init; }
    public string? AwardsTitles { get; init; }
    public bool OnCampus { get; init; }
    public string? ResearchAreas { get; init; }
    public string? AccrediationStartDate { get; init; }
    public string? ParticiptionEnrolment { get; init; }
    public string? VceEnglish { get; init; }
    public string? IbOther { get; init; }
    public bool Online { get; init; }
    public string? ProgressToMasters { get; init; }
    public string? AdditionalInfo { get; init; }
    public bool CriscosDisclaimerApplicable { get; init; }
    public string? OtherDescription { get; init; }
    public bool Other { get; init; }
    public bool HealthRecordsAndPrivacy { get; init; }
    public bool InformationDeclaration { get; init; }
    public string? Ahegs { get; init; }
    public bool ProhibitedEmploymentDeclaration { get; init; }
    public string? MinimumEntryRequirements { get; init; }
    public string? EccrediationEndDate { get; init; }
    public string? AccrediationEnd { get; init; }
    public string? PostNominals { get; init; }
    public string? IbEnglish { get; init; }
    public string? CreditArrangements { get; init; }
    public string? Outcomes { get; init; }
    public string? MajorMinors { get; init; }
    public string? VceMaths { get; init; }
    public string? DegreesAwarded { get; init; }
    public string? NonYear12Entry { get; init; }
    public bool WorkingWithChildrenCheck { get; init; }
    public string? EntryPathwaysAndAdjustmentFactorsOtherDetails { get; init; }
    public List<string?>? EntryPathwaysAndAdjustmentFactors { get; init; }
    public bool DoesUndergraduatePrinciple_26_3Apply { get; init; }
    public bool FormalArticulationPathwayToHigherAward { get; init; }
    public string? ApplicationMethodOtherDetails { get; init; }
    public string? IeltsOverallScore { get; init; }
    public string? IsThisAnAcceleratedCourse { get; init; }
    public string? HowDoesThisCourseDeliverACapstoneExperience { get; init; }
    public string? HoursPerWeek { get; init; }
    public string? ExclusivelyAnExitAward { get; init; }
    public string? IeltsListeningScore { get; init; }
    public string? AdmissionToCombinedDouble { get; init; }
    public string? IELTS_speaking_score { get; init; }
    public string? CapstoneOrProfessionalPractice { get; init; }
    public string? ExternalBody { get; init; }
    public string? OtherProviderName { get; init; }
    public string? ProviderNameAndSupportingDocumentation { get; init; }
    public string? Arrangements { get; init; }
    public string? NumberOfWeeks { get; init; }
    public List<string?>? ApplicationMethod { get; init; }
    public bool DeliveryWithThirdPartyProvider { get; init; }
    public bool AreThereAdditionalAdmissionPoints { get; init; }
    public string? VolumeOfLearning { get; init; }
    public string? AwardAbbreviation { get; init; }
    public string? AdmissionRequirements { get; init; }
    public bool AnyDoubleDegreeExclusions { get; init; }
    public string? IeltsWritingScore { get; init; }
    public string? AhegsAwardText { get; init; }
    public bool WorkBasedTrainingComponent { get; init; }
    public string? IeltsReadingScore { get; init; }
    public string? WamRequiredForProgression { get; init; }
    public string? AccrediationTextForAhegs { get; init; }
    public string? ProviderName { get; init; }
    public string? AssessmentRegulations { get; init; }
    public bool AccrediatedByExternalBody { get; init; }
    public bool OfferedByAnExternalProvider { get; init; }
    public string? Assessment { get; init; }
    public List<OrgUnitDataDto>? Level2OrgUnitData { get; init; }
    public List<string?>? RelatedAssociatedItems { get; init; }
    public List<OfferingDto>? Offering { get; init; }
    public List<string?>? StudyModes { get; init; }
    public List<AdmissionRequirementPointDto>? AdditionalAdmissionPoints { get; init; }
    public List<string?>? CourseRules { get; init; }
    public List<CourseNoteDto>? CourseNotes { get; init; }
    public List<LearningOutcomeDto>? LearningOutcomes { get; init; }
    public List<HigherLevelCoursesThatStudentsMayExitFrom>? HigherLevelCoursesThatStudentsMayExitFrom { get; init; }
    public List<OrgUnitDataDto>? Level1OrgUnitData { get; init; }
    public List<Articulation>? Articulations { get; init; }
    public string? CourseSearchTitle { get; init; }
    public string? AvailableInDoubles { get; init; }
    public string? AvailableDoubles { get; init; }
    public string? AvailableAOS { get; init; }

    public string? ExtId { get; init; }

    public string? VersionName { get; init; }

    public List<FeeDto>? Fees { get; init; }

    public string? CourseDurationInYears { get; init; }

    public string? MaximumDuration { get; init; }

    public string? FullTimeDuration { get; init; }

    public string? PartTimeDuration { get; init; }

    public string? FeesDescription { get; init; }

    public string? CricosCode { get; init; }
}
