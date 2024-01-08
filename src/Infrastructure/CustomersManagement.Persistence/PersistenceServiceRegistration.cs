using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Persistence.DatabaseContext;
using CustomersManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomersManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ClientsDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("ClientsDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IClientRepository, ClientRepository>();
        services.AddScoped<IAddressRepository, AddressReposiotry>();
        services.AddScoped<IDocumentRepository, DocumentRepository>();

        return services;
    }
}
