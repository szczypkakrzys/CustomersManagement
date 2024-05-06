using CustomersManagement.UI.Models;

namespace CustomersManagement.UI.Contracts;

public interface IAuthenticationService
{
    Task<bool> AuthenticateAsync(string email, string password);
    Task<bool> RegisterAsync(RegisterVM registerRequest);
    Task Logout();
}
