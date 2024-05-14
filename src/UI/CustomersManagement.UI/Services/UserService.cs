using AutoMapper;
using Blazored.LocalStorage;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Emloyee;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Services;

public class UserService : BaseHttpService, IUserService
{
    private readonly IMapper _mapper;

    public UserService(
        IClient client,
        ILocalStorageService localStorageService,
        IMapper mapper) : base(client, localStorageService)
    {
        _mapper = mapper;
    }

    public async Task<Response<Guid>> Register(RegisterVM request)
    {
        try
        {
            await AddBearerToken();

            var registerCommand = _mapper.Map<RegisterNewUserCommand>(request);
            await _client.UsersPOSTAsync(registerCommand);

            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<IEnumerable<EmployeeVM>> GetByRole(Role role)
    {
        await AddBearerToken();
        var result = await _client.UsersAllAsync(role);
        return _mapper.Map<IEnumerable<EmployeeVM>>(result);
    }

    public async Task<Response<Guid>> Delete(string userId)
    {
        try
        {
            await AddBearerToken();
            await _client.UsersDELETEAsync(userId);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }

    public async Task<Response<Guid>> ChangeEmail(string userId, string newEmail)
    {
        try
        {
            await AddBearerToken();
            var updateUserEmailCommand = new UpdateUserEmailCommand
            {
                Id = userId,
                NewEmail = newEmail
            };
            await _client.UsersPUTAsync(updateUserEmailCommand);
            return new Response<Guid>() { IsSuccess = true };
        }
        catch (ApiException ex)
        {
            return ConvertApiExceptions<Guid>(ex);
        }
    }
}
