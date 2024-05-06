using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.TravelAgency;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.TravelAgencyCustomers;

public partial class Details
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    ITravelAgencyCustomerService Customer { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    [Parameter]
    public int Id { get; set; }

    TravelAgencyCustomerDetailsVM customer = new();
    public string Message { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        customer = await Customer.GetCustomerDetails(Id);
    }
    protected void EditCustomer(int id)
    {
        NavManager.NavigateTo($"/travelagency/customers/edit/{id}");
    }

    protected async void DeleteCustomer(int id)
    {
        var response = await Customer.DeleteCustomer(id);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/travelagency/customers/");
            _message.Info("Poprawnie usuniêto dane klienta");
        }
        else
        {
            _message.Error("Nie uda³o sie usun¹æ danych klienta");
            Message = response.Message;
        }
    }
}