using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.TravelAgency;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class CustomersToursRelationsRepository : GenericRepository<CustomersToursRelations>, ICustomersToursRelationsRepository
{
    public CustomersToursRelationsRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<CustomersToursRelations> GetCustomerTourDetails(int customerId, int tourId)
    {
        return await _context.Set<CustomersToursRelations>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(q =>
                                q.CustomerId == customerId &&
                                q.TourId == tourId);
    }

    public async Task<bool> IsNotAlreadyAssigned(
        int customerId,
        int tourId)
    {
        var result = await _context.CustomersToursRelations
            .AnyAsync(q =>
                q.CustomerId == customerId &&
                q.TourId == tourId);

        return !result;
    }
}
