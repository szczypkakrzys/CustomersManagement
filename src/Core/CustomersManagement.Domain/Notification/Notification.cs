using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.Notification;

public class Notification : BaseEntity
{
    public string Message { get; set; }
    public string ApplicationUserId { get; set; }
    public int? ActivityId { get; set; }
    public List<int>? CustomersIdsList { get; set; } = new List<int>();
    public NotificationType Type { get; set; }
    public DateOnly Date { get; set; }
}
