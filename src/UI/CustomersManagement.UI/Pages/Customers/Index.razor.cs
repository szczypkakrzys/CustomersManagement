using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Customers;

public partial class Index
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ICustomerService Customer { get; set; }

    public List<CustomerVM> Customers { get; private set; }
    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadCustomers();
    }

    protected void CreateCustomer()
    {
        NavManager.NavigateTo("/customers/create/");
    }

    protected void EditCustomer(int id)
    {
        NavManager.NavigateTo($"/customers/edit/{id}");
    }

    protected void CustomerDetails(int id)
    {
        NavManager.NavigateTo($"/customers/details/{id}");
    }

    protected async Task DeleteCustomer(int id)
    {
        var response = await Customer.DeleteCustomer(id);
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
        Customers = await Customer.GetAllCustomers();
    }

}