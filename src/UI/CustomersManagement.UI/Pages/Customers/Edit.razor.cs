using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Edit
{
    [Inject]
    ICustomerService _client { get; set; }
    [Inject]
    NavigationManager _navManager { get; set; }

    [Parameter]
    public int id { get; set; }
    public string Message { get; private set; }

    CustomerVM customer = new CustomerVM();

    protected override async Task OnParametersSetAsync()
    {
        customer = await _client.GetCustomerDetails(id);
    }

    private async Task UpdateCustomer()
    {
        var response = await _client.UpdateCustomer(id, customer);
        if (response.IsSuccess)
        {
            _navManager.NavigateTo("/customers/");
        }
        Message = response.Message;
    }
}