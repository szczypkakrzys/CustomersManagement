using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ITravelAgencyCustomerService Customer { get; set; }

    public string Message { get; set; } = string.Empty;

    public TravelAgencyCustomerDetailsVM Model { get; set; } = new TravelAgencyCustomerDetailsVM
    {
        Address = new AddressVM()
    };

    async Task CreateCustomer()
    {
        var response = await Customer.CreateCustomer(Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/travelagency/customers/");
        }
        Message = response.Message;
    }
}
