using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.AssignCustomerToCourse;

public class AssignCustomerToCourseCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int CourseId { get; set; }
}