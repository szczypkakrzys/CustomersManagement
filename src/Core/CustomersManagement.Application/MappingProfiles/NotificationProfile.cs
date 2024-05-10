using AutoMapper;
using CustomersManagement.Domain.Notification;

namespace CustomersManagement.Application.MappingProfiles;

public class NotificationProfile : Profile
{
    public NotificationProfile()
    {
        CreateMap<Notification, Notification>();
    }
}
