using CustomersManagement.Application.Models.Identity;

namespace CustomersManagement.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<Employee>> GetEmployees();
    Task<Employee> GetEmployee(string userId);
}
