using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Details
{
    [Inject]
    ICustomerService _customer { get; set; }

    [Parameter]
    public int id { get; set; }

    CustomerVM customer = new CustomerVM();

    protected override async Task OnParametersSetAsync()
    {
        customer = await _customer.GetCustomerDetails(id);
    }
}