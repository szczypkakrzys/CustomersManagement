using AutoMapper;
using Blazored.LocalStorage;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class TravelAgencyCustomerService : BaseHttpService, ITravelAgencyCustomerService
{
    private readonly IMapper _mapper;

    public TravelAgencyCustomerService(
        IClient client,
        IMapper mapper,
        ILocalStorageService localStorageService) : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> CreateCustomer(TravelAgencyCustomerDetailsVM customer)
    {
        try
        {
            await AddBearerToken();
            var createCustomerCommand = _mapper.Map<CreateTravelAgencyCustomerCommand>(customer);
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
            await AddBearerToken();
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
        await AddBearerToken();
        var customers = await _client.CustomersAllAsync();
        return _mapper.Map<List<CustomerVM>>(customers);
    }

    public async Task<TravelAgencyCustomerDetailsVM> GetCustomerDetails(int id)
    {
        await AddBearerToken();
        var customer = await _client.CustomersGETAsync(id);
        return _mapper.Map<TravelAgencyCustomerDetailsVM>(customer);
    }

    public async Task<Response<Guid>> UpdateCustomer(int id, TravelAgencyCustomerDetailsVM customer)
    {
        try
        {
            await AddBearerToken();
            var updateCustomerCommand = _mapper.Map<UpdateTravelAgencyCustomerCommand>(customer);
            await _client.CustomersPUTAsync(id.ToString(), updateCustomerCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
