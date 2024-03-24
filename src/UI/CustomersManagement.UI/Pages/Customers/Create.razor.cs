using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ICustomerService Customer { get; set; }

    public string Message { get; set; } = string.Empty;

    public CustomerVM Model = new();

    async Task CreateCustomer()
    {
        var response = await Customer.CreateCustomer(Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/customers/");
        }
        Message = response.Message;
    }
}
