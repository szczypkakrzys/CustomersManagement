using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Commands.DeleteNotification;

public class DeleteNotificationCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
