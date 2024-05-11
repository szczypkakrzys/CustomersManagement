using CustomersManagement.Domain.Notification;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface INotificationRepository : IGenericRepository<Notification>
{
    Task<IEnumerable<Notification>> GetUserNotifications(string userId);
}
