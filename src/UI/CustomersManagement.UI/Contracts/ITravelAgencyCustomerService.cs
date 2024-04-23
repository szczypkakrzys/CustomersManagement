using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ITravelAgencyCustomerService
{
    Task<List<CustomerVM>> GetAllCustomers();
    Task<TravelAgencyCustomerDetailsVM> GetCustomerDetails(int id);
    Task<Response<Guid>> CreateCustomer(TravelAgencyCustomerDetailsVM customer);
    Task<Response<Guid>> UpdateCustomer(int id, TravelAgencyCustomerDetailsVM customer);
    Task<Response<Guid>> DeleteCustomer(int id);
}
