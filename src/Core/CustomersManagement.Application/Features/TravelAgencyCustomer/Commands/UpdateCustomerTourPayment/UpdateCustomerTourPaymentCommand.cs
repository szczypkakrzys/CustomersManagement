using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.UpdateCustomerPayment;

public class UpdateCustomerTourPaymentCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int TourId { get; set; }
    public int PaymentAmount { get; set; }
}
