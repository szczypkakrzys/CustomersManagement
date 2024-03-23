using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Details
{
    [Inject]
    ICustomerService Customer { get; set; }

    [Parameter]
    public int Id { get; set; }

    CustomerVM customer = new();

    protected override async Task OnParametersSetAsync()
    {
        customer = await Customer.GetCustomerDetails(Id);
    }
}