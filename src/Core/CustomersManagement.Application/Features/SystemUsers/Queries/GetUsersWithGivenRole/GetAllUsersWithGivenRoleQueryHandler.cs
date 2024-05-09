using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Models.Identity;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Queries.GetUsersWithGivenRole;

public class GetAllUsersWithGivenRoleQueryHandler : IRequestHandler<GetAllUsersWithGivenRoleQuery, IEnumerable<Employee>>
{
    private readonly IUserService _userService;

    public GetAllUsersWithGivenRoleQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<IEnumerable<Employee>> Handle(
        GetAllUsersWithGivenRoleQuery request,
        CancellationToken cancellationToken)
    {
        return await _userService.GetEmployeesByRole(RoleName.GetRoleName(request.Role));
    }
}
