using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;

public record class GetUserNotificationsQuery(string userId) : IRequest<IEnumerable<NotificationDto>>;
