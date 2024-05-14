using CustomersManagement.UI.Models.Notification;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ICustomNotificationService
{
    Task<Response<Guid>> Delete(int id);
    Task<List<NotificationVM>> GetUserNotifications(string userId);
    void ClearNotifications();
    Task<string> MapNotificationName(NotificationVM notification);
    Task<List<NotificationCustomerVM>> NotificationsCustomers(NotificationVM notification);
}
