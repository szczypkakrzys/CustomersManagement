using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.AssignCustomerToTour;

public class AssignCustomerCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int TourId { get; set; }
}
