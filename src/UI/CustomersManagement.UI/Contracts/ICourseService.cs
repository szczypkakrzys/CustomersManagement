using CustomersManagement.UI.Models.DivingSchool;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ICourseService
{
    Task<List<ActivityVM>> GetAllCourses();
    Task<CourseDetailsVM> GetCourseDetails(int id);
    Task<Response<Guid>> CreateCourse(CourseDetailsVM course);
    Task<Response<Guid>> UpdateCourse(int id, CourseDetailsVM course);
    Task<Response<Guid>> DeleteCourse(int id);
    Task<List<ActivityParticipantVM>> GetCourseParticipants(int courseId);
}
