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
            var createCustomerCommand = _mapper.Map<CreateClientCommand>(customer);
            await _client.ClientsPOSTAsync(createCustomerCommand);
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
            await _client.ClientsDELETEAsync(id);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<List<CustomerVM>> GetAllCustomers()
    {
        var customers = await _client.ClientsAllAsync();
        return _mapper.Map<List<CustomerVM>>(customers);
    }

    public async Task<CustomerVM> GetCustomerDetails(int id)
    {
        var customer = await _client.ClientsGETAsync(id);
        return _mapper.Map<CustomerVM>(customer);
    }

    public async Task<Response<Guid>> UpdateCustomer(int id, CustomerVM customer)
    {
        try
        {
            var updateCustomerCommand = _mapper.Map<UpdateClientCommand>(customer);
            await _client.ClientsPUTAsync(id.ToString(), updateCustomerCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
