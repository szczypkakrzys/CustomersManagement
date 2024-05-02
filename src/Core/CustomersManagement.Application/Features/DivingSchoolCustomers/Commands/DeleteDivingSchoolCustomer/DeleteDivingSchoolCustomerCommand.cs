using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.DeleteDivingSchoolCustomer;

public class DeleteDivingSchoolCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
