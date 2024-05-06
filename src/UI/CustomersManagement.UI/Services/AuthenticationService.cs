using AutoMapper;
using Blazored.LocalStorage;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Providers;
using CustomersManagement.UI.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;

namespace CustomersManagement.UI.Services;

public class AuthenticationService : BaseHttpService, IAuthenticationService
{
    private readonly IMapper _mapper;
    private readonly AuthenticationStateProvider _authenticationStateProvider;

    public AuthenticationService(
        IClient client,
        ILocalStorageService localStorageService,
        IMapper mapper,
        AuthenticationStateProvider authenticationStateProvider) : base(client, localStorageService)
    {
        _mapper = mapper;
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
        await ((ApiAuthenticationStateProvider)
            _authenticationStateProvider).LoggedOut();
    }

    public async Task<bool> RegisterAsync(RegisterVM request)
    {
        var registrationRequest = _mapper.Map<RegistrationRequest>(request);

        var response = await _client.RegisterAsync(registrationRequest);

        if (string.IsNullOrEmpty(response.UserId))
            return false;

        return true;
    }
}
