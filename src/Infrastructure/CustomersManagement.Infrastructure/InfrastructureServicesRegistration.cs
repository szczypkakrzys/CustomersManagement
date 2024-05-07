using CustomersManagement.Application.Contracts.Email;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Models.Email;
using CustomersManagement.Infrastructure.Email;
using CustomersManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomersManagement.Infrastructure;

public static class InfrastructureServicesRegistration
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
