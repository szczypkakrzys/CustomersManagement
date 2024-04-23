using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Edit
{
    [Inject]
    ITravelAgencyCustomerService Customer { get; set; }

    [Inject]
    NavigationManager NavManager { get; set; }

    [Parameter]
    public int Id { get; set; }
    public string Message { get; private set; }

    TravelAgencyCustomerDetailsVM Model = new();

    protected override async Task OnParametersSetAsync()
    {
        Model = await Customer.GetCustomerDetails(Id);
    }

    private async Task UpdateCustomer()
    {
        var response = await Customer.UpdateCustomer(Id, Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/travelagency/customers/");
        }
        Message = response.Message;
    }
}