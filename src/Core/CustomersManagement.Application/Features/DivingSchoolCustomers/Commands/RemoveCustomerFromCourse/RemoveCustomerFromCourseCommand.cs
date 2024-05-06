using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.RemoveCustomerFromCourse;

public class RemoveCustomerFromCourseCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
}