namespace CustomersManagement.Domain.Common;

public class CustomersActivitiesRelations : BaseEntity
{
    public DateTime EnrollmentDate { get; set; }
    public string Status { get; set; }
    public DateOnly AdvancedPaymentDate { get; set; }
    public DateOnly EntireAmountPaymentDate { get; set; }
    public int AdvancedPaymentAmountPaid { get; set; }
    public int EntireAmountPaymentAmountPaid { get; set; }
}
