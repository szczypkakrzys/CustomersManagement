using CustomersManagement.Domain.DivingSchool;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IDivingSchoolCustomerRepository : IGenericRepository<DivingSchoolCustomer>
{
    Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress);
}
