using CustomersManagement.Domain.DivingSchool;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IDivingSchoolCustomerRepository : IGenericRepository<DivingSchoolCustomer>
{
    Task<DivingSchoolCustomer> GetByIdWithTours(int id);
    Task<bool> IsCustomerUnique(
        string firstName,
        string lastName,
        string emailAddress);
    Task<IEnumerable<DivingSchoolCustomer>> GetCustomersByDateOfBirth(DateOnly date);
}
