using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.UpdateCustomerPayment;

public class UpdateCustomerTourPaymentCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int TourId { get; set; }
    public double PaymentAmount { get; set; }
}
