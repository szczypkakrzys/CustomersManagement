using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Emloyee;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface IUserService
{
    Task<Response<Guid>> Register(RegisterVM request);
    Task<IEnumerable<EmployeeVM>> GetByRole(Role role);
    Task<Response<Guid>> Delete(string userId);
    Task<Response<Guid>> ChangeEmail(string userId, string newEmail);
}
