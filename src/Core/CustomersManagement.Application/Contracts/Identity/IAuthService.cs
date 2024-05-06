using CustomersManagement.Application.Models.Identity;

namespace CustomersManagement.Application.Contracts.Identity;

public interface IAuthService
{
    Task<AuthResponse> Login(AuthRequest request);
    Task<RegistrationResponse> Register(RegistrationRequest request);
}
