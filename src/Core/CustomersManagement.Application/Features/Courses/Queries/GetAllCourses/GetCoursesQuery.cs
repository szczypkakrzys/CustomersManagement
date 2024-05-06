using MediatR;

namespace CustomersManagement.Application.Features.Courses.Queries.GetAllCourses;

public record GetCoursesQuery : IRequest<IEnumerable<CourseDto>>;
