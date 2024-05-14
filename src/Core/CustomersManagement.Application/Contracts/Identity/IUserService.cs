using CustomersManagement.Application.Features.SystemUsers.Commands.RegisterNewUser;
using CustomersManagement.Application.Models.Identity;

namespace CustomersManagement.Application.Contracts.Identity;

public interface IUserService
{
    Task<IEnumerable<Employee>> GetEmployeesByRole(string roleName);
    Task<Employee> GetEmployee(string userId);
    public string UserId { get; }
    Task<RegistrationResponse> Register(RegisterNewUserCommand request);
    Task DeleteEmployee(string userId);
    Task ChangeEmail(string userId, string newEmail);
}
