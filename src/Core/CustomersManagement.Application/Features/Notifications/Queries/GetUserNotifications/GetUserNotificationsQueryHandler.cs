using AutoMapper;
using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Models.Identity;
using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;

public class GetUserNotificationsQueryHandler : IRequestHandler<GetUserNotificationsQuery, IEnumerable<NotificationDto>>
{
    private readonly IUserService _userService;
    private readonly INotificationRepository _notificationRepository;
    private readonly IMapper _mapper;

    public GetUserNotificationsQueryHandler(
        IUserService userService,
        INotificationRepository notificationRepository,
        IMapper mapper)
    {
        _userService = userService;
        _notificationRepository = notificationRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<NotificationDto>> Handle(
        GetUserNotificationsQuery request,
        CancellationToken cancellationToken)
    {
        var employee = await _userService.GetEmployee(request.UserId) ??
            throw new NotFoundException(nameof(Employee), request.UserId);

        var notifications = await _notificationRepository.GetUserNotifications(request.UserId);

        var data = _mapper.Map<IEnumerable<NotificationDto>>(notifications);

        return data;
    }
}
