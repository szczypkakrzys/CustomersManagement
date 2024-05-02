using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgency;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ITravelAgencyCustomerService Customer { get; set; }

    [Inject]
    IMessageService _message { get; set; }

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
            _message.Success("Poprawnie dodano nowego klienta");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda�o si� doda� klienta");
        }
    }
}
