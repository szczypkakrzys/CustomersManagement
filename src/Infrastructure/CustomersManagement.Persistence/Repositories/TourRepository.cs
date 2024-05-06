using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.TravelAgency;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class TourRepository : GenericRepository<Tour>, ITourRepository
{
    public TourRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<Tour> GetByIdWithParticipants(int id)
    {
        return await _context.Set<Tour>()
                            .Include(p => p.Participants)
                            .AsNoTracking()
                            .FirstOrDefaultAsync(q => q.Id == id);
    }
}
