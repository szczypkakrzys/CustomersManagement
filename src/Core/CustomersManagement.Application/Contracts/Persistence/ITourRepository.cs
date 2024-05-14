using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface ITourRepository : IGenericRepository<Tour>
{
    Task<Tour> GetByIdWithParticipants(int id);
    Task<List<Tour>> GetToursWithRelationsByDate(DateOnly date);
}
