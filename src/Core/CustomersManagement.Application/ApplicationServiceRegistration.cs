using CustomersManagement.Application.Contracts.Notifications;
using CustomersManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CustomersManagement.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddScoped<IEventProcessor, EventProcessorService>();
        services.AddScoped<INotificationService, NotificationService>();

        return services;
    }
}
