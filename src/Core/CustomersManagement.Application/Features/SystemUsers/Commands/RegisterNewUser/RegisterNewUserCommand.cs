using CustomersManagement.Application.Models.Identity;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Commands.RegisterNewUser;

public class RegisterNewUserCommand : IRequest<string>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}
