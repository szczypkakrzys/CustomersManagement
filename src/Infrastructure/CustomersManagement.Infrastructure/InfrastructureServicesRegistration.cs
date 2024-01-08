using CustomersManagement.Application.Contracts.Logging;
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
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        //todo
        //when finally ready - add services to infastructure there
        //services.AddScoped(typeof(DocumentFormsService<>), typeof(IDocumentsFormFill<>));

        return services;
    }
}
