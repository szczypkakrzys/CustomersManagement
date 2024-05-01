using MediatR;

namespace CustomersManagement.Application.Features.Tours.Commands.UpdateTour;

public class UpdateTourCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime TimeStart { get; set; }
    public DateTime TimeEnd { get; set; }
    public double EntireCost { get; set; }
    public double AdvancePaymentCost { get; set; }
    public DateTime EntireAmountPaymentDeadline { get; set; }
    public DateTime AdvancePaymentDeadline { get; set; }
    public string Status { get; set; }
}
