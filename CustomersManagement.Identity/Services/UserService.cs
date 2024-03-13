using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace CustomersManagement.Identity.Services;

public class UserService : IUserService
{
    private readonly UserManager<ApplicationUser> _userManager;

    public UserService(UserManager<ApplicationUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<Employee>> GetEmployees()
    {
        var employees = await _userManager.GetUsersInRoleAsync("Employee");
        return employees.Select(employee => new Employee
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            EmailAddress = employee.Email
        }).ToList();
    }

    public async Task<Employee> GetEmployee(string userId)
    {
        var employee = await _userManager.FindByIdAsync(userId);
        //TODO
        //can use automapper here 
        //same in above method :)
        return new Employee
        {
            Id = employee.Id,
            FirstName = employee.FirstName,
            LastName = employee.LastName,
            EmailAddress = employee.Email
        };
    }
}
