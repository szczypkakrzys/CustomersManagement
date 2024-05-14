using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.Notification;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Notification>> GetUserNotifications(string userId)
    {
        return await _context.Notifications
        .Where(notification => notification.ApplicationUserId == userId)
        .ToListAsync();
    }
}
