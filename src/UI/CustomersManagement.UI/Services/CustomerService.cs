using AutoMapper;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class CustomerService : BaseHttpService, ICustomerService
{
    private readonly IMapper _mapper;

    public CustomerService(
        IClient client,
        IMapper mapper) : base(client)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateCustomer(CustomerVM customer)
    {
        try
        {
            var createCustomerCommand = _mapper.Map<CreateCustomerCommand>(customer);
            await _client.CustomersPOSTAsync(createCustomerCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> DeleteCustomer(int id)
    {
        try
        {
            await _client.CustomersDELETEAsync(id);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<CustomerVM>> GetAllCustomers()
    {
        var customers = await _client.CustomersAllAsync();
        return _mapper.Map<List<CustomerVM>>(customers);
    }

    public async Task<CustomerVM> GetCustomerDetails(int id)
    {
        var customer = await _client.CustomersGETAsync(id);
        return _mapper.Map<CustomerVM>(customer);
    }

    public async Task<Response<Guid>> UpdateCustomer(int id, CustomerVM customer)
    {
        try
        {
            var updateCustomerCommand = _mapper.Map<UpdateCustomerCommand>(customer);
            await _client.CustomersPUTAsync(id.ToString(), updateCustomerCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
