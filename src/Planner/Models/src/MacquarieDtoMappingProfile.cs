using AutoMapper;
using Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;
using Courseloop.Models.Unit.Prerequisites;
using Planner.Models.Course;
using Planner.Models.Shared;
using Planner.Models.Unit;
using Planner.Models.Unit.Prerequisites;

namespace Planner.Models;

public class MacquarieDtoMappingProfile : Profile {

    private static bool ShouldMapMember(object value) {
        if (value is null) return false;
        if (value.GetType().Equals(typeof(string))) {
            return !string.IsNullOrWhiteSpace((string)value);
        } else {
            return true;
        }
    }

    public MacquarieDtoMappingProfile() {
        AllowNullCollections = true;

        CreateMap<MacquarieUnit, UnitDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
        CreateMap<MacquarieUnitData, UnitDataDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
        CreateMap<LearningOutcome, LearningOutcomeDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
        CreateMap<EnrolmentRule, EnrolmentRuleDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<Assessment, AssessmentDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<UnitOffering, UnitOfferingDto>()
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Value))
            .ForMember(dest => dest.AcademicItem, opt => opt.MapFrom(src => src.AcademicItem.Value))
            .ForMember(dest => dest.AttendanceMode, opt => opt.MapFrom(src => src.AttendanceMode.Value))
            .ForMember(dest => dest.TeachingPeriod, opt => opt.MapFrom(src => src.TeachingPeriod.Value))
            .ForMember(dest => dest.StudyLevel, opt => opt.MapFrom(src => src.StudyLevel.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<LearningActivity, LearningActivityDto>()
            .ForMember(dest => dest.Activity, opt => opt.MapFrom(src => src.Activity.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<Requisite, RequisiteDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.RequisiteType.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<ContainerRequisiteTemporaryName, RequisiteContainerDto>()
            .ForMember(dest => dest.Connector, opt => opt.MapFrom(src => src.ParentConnector.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<MacquarieCourse, CourseDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<MacquarieCourseData, CourseDataDto>()
            .ForMember(dest => dest.AqfLevel, opt => opt.MapFrom(src => src.AqfLevel.Label))
            .ForMember(dest => dest.GovtSpecialCourseType, opt => opt.MapFrom(src => src.GovtSpecialCourseType.Value))
            .ForMember(dest => dest.PartnerFaculty, opt => opt.MapFrom(src => src.PartnerFaculty.Value))
            .ForMember(dest => dest.ExclusivelyAnExitAward, opt => opt.MapFrom(src => src.ExclusivelyAnExitAward.Label))
            .ForMember(dest => dest.VolumeOfLearning, opt => opt.MapFrom(src => src.VolumeOfLearning.Label))
            .ForMember(dest => dest.CourseDurationInYears, opt => opt.MapFrom(src => src.CourseDurationInYears.Label))
            .ForMember(dest => dest.CourseValue, opt => opt.MapFrom(src => src.CourseValue.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<MacquarieCurriculumStructureData, CurriculumStructureDataDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
        CreateMap<UnitGroupingContainer, UnitGroupingContainerDto>()
            .ForMember(dest => dest.ParentRecord, opt => opt.MapFrom(src => src.ParentRecord.Value))
            .ForMember(dest => dest.ParentRecord, opt => opt.MapFrom(src => src.ParentRecord.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<Offering, OfferingDto>()
            .ForMember(dest => dest.AdmissionCalendar, opt => opt.MapFrom(src => src.AdmissionCalendar.Value))
            .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location.Value))
            .ForMember(dest => dest.Mode, opt => opt.MapFrom(src => src.Mode.Value))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<AcademicItem, AcademicItemDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Label))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<OrgUnitData, OrgUnitDataDto>()
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
        CreateMap<Fee, FeeDto>()
            .ForMember(dest => dest.FeeType, opt => opt.MapFrom(src => src.FeeType.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<CourseNote, CourseNoteDto>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<AdmissionRequirementPoint, AdmissionRequirementPointDto>()
           .ForMember(dest => dest.VolumeOfLearning, opt => opt.MapFrom(src => src.VolumeOfLearning.Label))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));

        CreateMap<LabelledValue, string>().ConvertUsing(src => src.Label);
        CreateMap<KeyValueIdType, string>().ConvertUsing(src => src.Value);

        CreateMap<MacquarieMaterialMetadata, MaterialMetadataDto>()
            .ForMember(dest => dest.AcademicOrganisation, opt => opt.MapFrom(src => src.AcademicOrganisation.Value))
            .ForMember(dest => dest.School, opt => opt.MapFrom(src => src.School.Value))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Value))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.Value))
            .ForAllMembers(o => o.Condition((s, d, v) => ShouldMapMember(v)));
    }
}