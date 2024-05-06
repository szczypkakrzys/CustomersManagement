using MediatR;

namespace CustomersManagement.Application.Features.Courses.Queries.GetAllCourseParticipants;

public record GetCourseParticipantsQuery(int Id) : IRequest<IEnumerable<CourseParticipantDto>>;
