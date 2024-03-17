using Blazored.LocalStorage;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Providers;
using CustomersManagement.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace CustomersManagement.UI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(
        IClient client,
        ILocalStorageService localStorageService,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
    {
        _authenticationStateProvider = authenticationStateProvider;
    }

    public async Task<bool> AuthenticateAsync(string email, string password)
    {
        try
        {
            var authenticationRequest = new AuthRequest()
            {
                EmailAddress = email,
                Password = password
            };

            var authenticationResponse = await _client.LoginAsync(authenticationRequest);

            if (authenticationResponse.Token != string.Empty)
            {
                await _localStorage.SetItemAsync("token", authenticationResponse.Token);

                //set claims in Blazor and login state

                await ((ApiAuthenticationStateProvider)
                    _authenticationStateProvider).LoggedIn();

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }

    }

    public async Task Logout()
    {
        //remove claims in Blazor and invalidate login state
        await ((ApiAuthenticationStateProvider)
            _authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(string firstName, string lastName, string userName, string email, string password)
    {
        var registrationRequest = new RegistrationRequest()
        {
            FirstName = firstName,
            LastName = lastName,
            EmailAddress = email,
            UserName = userName,
            Password = password
        };

        var response = await _client.RegisterAsync(registrationRequest);

        if (string.IsNullOrEmpty(response.UserId))
            return false;

        return true;
    }
}
