using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Create
{
    [Inject]
    public NavigationManager _navManager { get; set; }

    [Inject]
    public ICustomerService _customer { get; set; }

    public string Message { get; set; } = string.Empty;

    CustomerVM customer = new();
    async Task CreateCustomer()
    {
        var response = await _customer.CreateCustomer(customer);
        if (response.IsSuccess)
        {
            _navManager.NavigateTo("/customers/");
        }
        Message = response.Message;
    }
}
