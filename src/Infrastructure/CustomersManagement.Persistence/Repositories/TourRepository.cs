using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.TravelAgency;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class TourRepository : GenericRepository<Tour>, ITourRepository
{
    public TourRepository(CustomerDatabaseContext context) : base(context)
    {
    }
}
