namespace CustomersManagement.Application.Features.Tours.Queries.GetTourDetails;

public class TourDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string TimeStart { get; set; }
    public string TimeEnd { get; set; }
    public int EntireCost { get; set; }
    public int AdvancePaymentCost { get; set; }
    public string EntireAmountPaymentDeadline { get; set; }
    public string AdvancePaymentDeadline { get; set; }
    public string Status { get; set; }
}
