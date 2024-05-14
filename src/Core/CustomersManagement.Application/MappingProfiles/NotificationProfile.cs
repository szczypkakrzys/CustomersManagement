using AutoMapper;
using CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;
using CustomersManagement.Domain.Notification;

namespace CustomersManagement.Application.MappingProfiles;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, Notification>();
        CreateMap<Notification, NotificationDto>();
    }
}
