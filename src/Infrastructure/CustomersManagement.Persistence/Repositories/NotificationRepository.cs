using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.Notification;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
{
    public NotificationRepository(CustomerDatabaseContext context) : base(context)
    {
    }
}
