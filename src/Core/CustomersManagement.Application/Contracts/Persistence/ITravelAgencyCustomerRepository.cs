using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface ITravelAgencyCustomerRepository : IGenericRepository<TravelAgencyCustomer>
{
    Task<TravelAgencyCustomer> GetByIdWithTours(int id);
    Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress);
}