using CustomersManagement.Domain.Notification;

namespace CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;

public class NotificationDto
{
    public int Id { get; set; }
    public string Message { get; set; }
    public int? ActivityId { get; set; }
    public IEnumerable<int>? CustomersIdsList { get; set; }
    public NotificationType Type { get; set; }
}
