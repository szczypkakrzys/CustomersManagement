using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class AddressReposiotry : GenericRepository<Address>, IAddressRepository
{
    public AddressReposiotry(CustomerDatabaseContext context) : base(context)
    {
    }
}
