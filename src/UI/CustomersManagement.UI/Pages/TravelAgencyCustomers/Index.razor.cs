using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Shared;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Index
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ITravelAgencyCustomerService Customer { get; set; }

    public List<CustomerVM> Customers { get; private set; }
    public string Message { get; set; } = string.Empty;

    protected override async Task OnInitializedAsync()
    {
        await LoadCustomers();
    }

    protected void CreateCustomer()
    {
        NavManager.NavigateTo("/travelagency/customers/create/");
    }

    protected void EditCustomer(int id)
    {
        NavManager.NavigateTo($"/travelagency/customers/edit/{id}");
    }

    protected void CustomerDetails(int id)
    {
        NavManager.NavigateTo($"/travelagency/customers/details/{id}");
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