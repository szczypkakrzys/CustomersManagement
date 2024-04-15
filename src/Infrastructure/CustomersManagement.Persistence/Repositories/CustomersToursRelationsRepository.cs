using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.TravelAgency;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class CustomersToursRelationsRepository : GenericRepository<CustomersToursRelations>, ICustomersToursRelationsRepository
{
    public CustomersToursRelationsRepository(CustomerDatabaseContext context) : base(context)
    {
    }
}
