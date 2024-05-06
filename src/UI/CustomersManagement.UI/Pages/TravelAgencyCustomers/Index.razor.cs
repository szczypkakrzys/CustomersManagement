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
    public string SearchText = "";
    List<CustomerVM> FilteredCustomers => Customers.Where(
            customer => (customer.FirstName + " " + customer.LastName + customer.EmailAddress).Contains(SearchText, StringComparison.CurrentCultureIgnoreCase)).ToList();
    protected override async Task OnInitializedAsync()
    {
        await LoadCustomers();
    }

    protected void CreateCustomer()
    {
        NavManager.NavigateTo("/travelagency/customers/create/");
    }

    protected void CustomerDetails(int id)
    {
        NavManager.NavigateTo($"/travelagency/customers/details/{id}");
    }

    protected async Task LoadCustomers()
    {
        Customers = await Customer.GetAllCustomers();
    }

    protected void CustomerTours(int id)
    {
        NavManager.NavigateTo($"/travelagency/customers/{id}/tours");
    }
}