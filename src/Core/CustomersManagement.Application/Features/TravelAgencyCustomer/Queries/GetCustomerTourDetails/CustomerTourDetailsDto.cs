namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetCustomerTourDetails;

public class CustomerTourDetailsDto
{
    public int Id { get; set; }
    public DateOnly EnrollmentDate { get; set; }
    public string Status { get; set; }
    public DateOnly? AdvancedPaymentDate { get; set; }
    public DateOnly? EntireAmountPaymentDate { get; set; }
    public int AdvancedPaymentAmountPaid { get; set; }
    public int EntireAmountPaymentAmountPaid { get; set; }
}
