using CustomersManagement.Domain;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface ICustomerRepository : IGenericRepository<Customer>
{
    //todo
    //add more client data basic validation
    //for update, etc.
    Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress);
}