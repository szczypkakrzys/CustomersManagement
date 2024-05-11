using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.Notification;
using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Commands.DeleteNotification;

public class DeleteNotificationCommandHandler : IRequestHandler<DeleteNotificationCommand, Unit>
{
    private readonly INotificationRepository _notificationRepository;

    public DeleteNotificationCommandHandler(INotificationRepository notificationRepository) =>
        _notificationRepository = notificationRepository;

    public async Task<Unit> Handle(
        DeleteNotificationCommand request,
        CancellationToken cancellationToken)
    {
        var notificationToDelete = await _notificationRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Notification), request.Id);

        await _notificationRepository.DeleteAsync(notificationToDelete);

        return Unit.Value;
    }
}
