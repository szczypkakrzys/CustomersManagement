using CustomersManagement.Domain;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress);
}