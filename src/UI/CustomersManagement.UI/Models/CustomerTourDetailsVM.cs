namespace CustomersManagement.UI.Models;

public class CustomerTourDetailsVM
{
    public int Id { get; set; }
    public string EnrollmentDate { get; set; }
    public string Status { get; set; }
    public string? AdvancedPaymentDate { get; set; }
    public string? EntireAmountPaymentDate { get; set; }
    public int AdvancedPaymentLeftToPay { get; set; }
    public int EntireCostLeftToPay { get; set; }
}
