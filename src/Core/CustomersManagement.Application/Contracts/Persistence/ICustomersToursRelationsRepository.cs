using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface ICustomersToursRelationsRepository : IGenericRepository<CustomersToursRelations>
{
    Task<CustomersToursRelations> GetCustomerTourDetails(int customerId, int tourId);
    Task<bool> IsNotAlreadyAssigned(int customerId, int tourId);
}
