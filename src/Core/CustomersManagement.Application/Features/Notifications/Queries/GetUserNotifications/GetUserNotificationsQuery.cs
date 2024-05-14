using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;

public record class GetUserNotificationsQuery(string UserId) : IRequest<IEnumerable<NotificationDto>>;
