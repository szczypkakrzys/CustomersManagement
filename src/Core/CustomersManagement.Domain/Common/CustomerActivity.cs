namespace CustomersManagement.Domain.Common;

public class CustomerActivity : BaseEntity
{
    public string Name { get; set; }
    public DateOnly TimeStart { get; set; }
    public DateOnly TimeEnd { get; set; }
    public int EntireCost { get; set; }
    public int AdvancePaymentCost { get; set; }
    public DateOnly EntireAmountPaymentDeadline { get; set; }
    public DateOnly AdvancePaymentDeadline { get; set; }
    public string Status { get; set; }
}
