namespace CustomersManagement.Domain.Common;

public class CustomersActivitiesRelations : BaseEntity
{
    public DateOnly EnrollmentDate { get; set; }
    public string Status { get; set; }
    public DateOnly? AdvancedPaymentDate { get; set; }
    public DateOnly? EntireAmountPaymentDate { get; set; }
    public int AdvancedPaymentLeftToPay { get; set; }
    public int EntireCostLeftToPay { get; set; }
}
