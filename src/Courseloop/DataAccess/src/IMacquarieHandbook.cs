namespace Courseloop.DataAccess;

using System.Threading;
using System.Threading.Tasks;
using Courseloop.Models.Course;
using Courseloop.Models.Shared;
using Courseloop.Models.Unit;

public interface IMacquarieHandbook
{
    Task<MacquarieDataCollection<MacquarieCourse>> GetAllCourses(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default);
    Task<MacquarieDataCollection<MacquarieUnit>> GetAllUnits(int? implementationYear = null, int limit = 3000, CancellationToken cancellationToken = default);
    Task<MacquarieCourse?> GetCourse(string courseCode, int? implementationYear = null, CancellationToken cancellationToken = default);
    Task<MacquarieUnit?> GetUnit(string unitCode, int? implementationYear = null, CancellationToken cancellationToken = default);
}
