using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages;

public partial class Register
{
    public RegisterVM Model { get; set; }

    [Inject]
    public NavigationManager NavManager { get; set; }

    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthService { get; set; }

    protected override void OnInitialized()
    {
        Model = new RegisterVM();
    }

    protected async Task HandleRegister()
    {
        var result = await AuthService.RegisterAsync(Model);

        if (result)
        {
            NavManager.NavigateTo("/");
        }
        Message = "Something went wrong, please try again.";
    }
}