using MediatR;

namespace CustomersManagement.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
