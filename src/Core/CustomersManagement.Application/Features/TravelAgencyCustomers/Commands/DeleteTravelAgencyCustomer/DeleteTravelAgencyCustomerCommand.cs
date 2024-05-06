using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.DeleteTravelAgencyCustomer;

public class DeleteTravelAgencyCustomerCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
