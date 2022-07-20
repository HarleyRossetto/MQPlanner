namespace Planner.Api.Services.DataAccess;

using Planner.Models.Course;
using Planner.Models.Unit;

public interface IHandbookDataProvider {
    Task<UnitDto?> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default);
    Task<CourseDto?> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default);
    Task<IEnumerable<CourseDto>> GetCoursesWithNameContainer(string courseName, int? implementationYear = null, CancellationToken cancellationToken = default);
    Task<List<UnitDto>> GetAllUnits(int? implementationyear, CancellationToken cancellationToken = default);
    Task<IEnumerable<string>> GetAllUnitIds(int? implementationyear, CancellationToken cancellationToken = default);
    Task<bool> DeleteMessyArchive();
}