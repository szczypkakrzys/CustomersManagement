using AutoMapper;
using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomersManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IMapper _mapper;

    public UserService(
        UserManager<ApplicationUser> userManager,
        IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }

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
