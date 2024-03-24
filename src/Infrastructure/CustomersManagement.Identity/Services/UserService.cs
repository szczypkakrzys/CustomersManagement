using AutoMapper;
using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace CustomersManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(
        UserManager<ApplicationUser> userManager,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor)
    {
        _userManager = userManager;
        _mapper = mapper;
        _contextAccessor = httpContextAccessor;
    }

    public string UserId { get => _contextAccessor.HttpContext?.User?.FindFirstValue("uid"); }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");

        return employees.Select(employee =>
            _mapper.Map<Employee>(employee))
            .ToList();
    }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);

        return _mapper.Map<Employee>(employee);
    }
}
