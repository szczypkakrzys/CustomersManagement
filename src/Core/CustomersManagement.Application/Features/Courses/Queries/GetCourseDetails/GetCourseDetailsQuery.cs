using MediatR;

namespace CustomersManagement.Application.Features.Courses.Queries.GetCourseDetails;

public record GetCourseDetailsQuery(int Id) : IRequest<CourseDetailsDto>;
