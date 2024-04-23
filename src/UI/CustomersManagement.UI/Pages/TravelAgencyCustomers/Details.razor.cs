using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.TravelAgencyCustomers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Details
{
    [Inject]
    ITravelAgencyCustomerService Customer { get; set; }

    [Parameter]
    public int Id { get; set; }

    TravelAgencyCustomerDetailsVM customer = new();

    protected override async Task OnParametersSetAsync()
    {
        customer = await Customer.GetCustomerDetails(Id);
    }
}