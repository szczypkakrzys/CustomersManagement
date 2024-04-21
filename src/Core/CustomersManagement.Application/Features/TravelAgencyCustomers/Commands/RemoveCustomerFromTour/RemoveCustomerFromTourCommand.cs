using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.RemoveCustomerFromTour;

public class RemoveCustomerFromTourCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int TourId { get; set; }
}
