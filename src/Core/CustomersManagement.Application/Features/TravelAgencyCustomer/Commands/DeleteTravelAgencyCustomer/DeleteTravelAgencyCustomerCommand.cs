using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteTravelAgencyCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
