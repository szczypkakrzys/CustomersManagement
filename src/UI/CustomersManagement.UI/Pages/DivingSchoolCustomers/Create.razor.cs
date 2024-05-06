using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.DivingSchool;
using CustomersManagement.UI.Models.Shared;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.DivingSchoolCustomers;

public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public IDivingSchoolCustomerService CustomerService { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    public string Message { get; set; } = string.Empty;

    public DivingSchoolCustomerDetailsVM Model { get; set; } = new DivingSchoolCustomerDetailsVM
    {
        Address = new AddressVM()
    };

    async Task CreateCustomer()
    {
        var response = await CustomerService.CreateCustomer(Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/divingschool/customers/");
            _message.Success("Poprawnie dodano nowego klienta");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda³o siê dodaæ klienta");
        }
    }
}