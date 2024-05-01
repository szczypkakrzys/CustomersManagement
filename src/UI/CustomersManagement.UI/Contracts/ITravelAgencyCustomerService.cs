using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ITravelAgencyCustomerService
{
    Task<List<CustomerVM>> GetAllCustomers();
    Task<TravelAgencyCustomerDetailsVM> GetCustomerDetails(int id);
    Task<Response<Guid>> CreateCustomer(TravelAgencyCustomerDetailsVM customer);
    Task<Response<Guid>> UpdateCustomer(int id, TravelAgencyCustomerDetailsVM customer);
    Task<Response<Guid>> DeleteCustomer(int id);
    Task<List<CustomerTourVM>> GetCustomerTours(int id);
    Task<Response<Guid>> AssignCustomerToTour(int customerId, int tourId);
    Task<CustomerTourDetailsVM> CustomerTourDetails(int customerId, int tourId);
    Task<Response<Guid>> UpdateCustomerPayment(int customerId, int tourId, int paymentAmount);
    Task<Response<Guid>> RemoveCustomerFromTour(int customerId, int tourId);
}
