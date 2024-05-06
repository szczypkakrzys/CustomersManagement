using CustomersManagement.UI.Models.Customers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ICustomerService
{
    Task<List<CustomerVM>> GetAllCustomers();
    Task<CustomerVM> GetCustomerDetails(int id);
    Task<Response<Guid>> CreateCustomer(CustomerVM customer);
    Task<Response<Guid>> UpdateCustomer(int id, CustomerVM customer);
    Task<Response<Guid>> DeleteCustomer(int id);
}
