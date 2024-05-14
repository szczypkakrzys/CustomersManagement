using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.DivingSchool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.DivingSchoolCustomers;

[Authorize(Policy = Policies.DivingSchool)]
public partial class Details
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    IDivingSchoolCustomerService CustomerService { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    [Parameter]
    public int Id { get; set; }

    DivingSchoolCustomerDetailsVM customer = new();
    public string Message { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        customer = await CustomerService.GetCustomerDetails(Id);
    }
    protected void EditCustomer(int id)
    {
        NavManager.NavigateTo($"/divingschool/customers/edit/{id}");
    }

    protected async void DeleteCustomer(int id)
    {
        var response = await CustomerService.DeleteCustomer(id);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/divingschool/customers/");
            _message.Info("Poprawnie usuni�to dane klienta");
        }
        else
        {
            _message.Error("Nie uda�o sie usun�� danych klienta");
            Message = response.Message;
        }
    }
}