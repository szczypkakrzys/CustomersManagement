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
        services.AddDbContext<CustomerDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CustomersDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICustomerRepository, CustomerRepository>();
        services.AddScoped<IAddressRepository, AddressReposiotry>();

        return services;
    }
}
