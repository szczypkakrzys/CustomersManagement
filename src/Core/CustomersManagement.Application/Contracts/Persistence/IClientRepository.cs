using CustomersManagement.Domain;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IClientRepository : IGenericRepository<Client>
{
    //todo
    //add more client data basic validation
    //for update, etc.
    Task<bool> IsClientUnique(
        string firstName,
        string lastName,
        string emailAddress);
}