using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Index
{
    [Inject]
    public NavigationManager _navManager { get; set; }

    [Inject]
    public ICustomerService _client { get; set; }

    public List<CustomerVM> customers { get; private set; }
    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadCustomers();
    }

    protected void CreateCustomer()
    {
        _navManager.NavigateTo("/customers/create/");
    }

    protected void EditCustomer(int id)
    {
        _navManager.NavigateTo($"/customers/edit/{id}");
    }

    protected void CustomerDetails(int id)
    {
        _navManager.NavigateTo($"/customers/details/{id}");
    }

    protected async Task DeleteCustomer(int id)
    {
        var response = await _client.DeleteCustomer(id);
        if (response.IsSuccess)
        {
            await LoadCustomers();
        }
        else
        {
            Message = response.Message;
        }
    }

    protected async Task LoadCustomers()
    {
        customers = await _client.GetAllCustomers();
    }

}