using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Edit
{
    [Inject]
    ICustomerService Customer { get; set; }

    [Inject]
    NavigationManager NavManager { get; set; }

    [Parameter]
    public int Id { get; set; }
    public string Message { get; private set; }

    CustomerVM customer = new();

    protected override async Task OnParametersSetAsync()
    {
        customer = await Customer.GetCustomerDetails(Id);
    }

    private async Task UpdateCustomer()
    {
        var response = await Customer.UpdateCustomer(Id, customer);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/customers/");
        }
        Message = response.Message;
    }
}