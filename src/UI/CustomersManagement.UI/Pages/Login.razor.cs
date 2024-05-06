using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages;

public partial class Login
{
    public LoginVM Model { get; set; }

    [Inject]
    public NavigationManager NavManager { get; set; }
    public string Message { get; set; }

    [Inject]
    private IAuthenticationService AuthService { get; set; }

    public Login()
    {

    }

    protected override void OnInitialized()
    {
        Model = new LoginVM();
    }

    protected async Task HandleLogin()
    {
        if (await AuthService.AuthenticateAsync(Model.Email, Model.Password))
        {
            NavManager.NavigateTo("/");
        }
        Message = "Username/password combination unknown";
    }
}