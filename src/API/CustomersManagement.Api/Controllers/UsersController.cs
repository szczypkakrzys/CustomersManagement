using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Features.SystemUsers.Commands.DeleteUser;
using CustomersManagement.Application.Features.SystemUsers.Commands.RegisterNewUser;
using CustomersManagement.Application.Features.SystemUsers.Commands.UpdateEmail;
using CustomersManagement.Application.Features.SystemUsers.Queries;
using CustomersManagement.Application.Models.Identity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UsersController : Controller
{
    private readonly IMediator _mediator;
    private readonly IUserService _userService;

    public UsersController(IMediator mediator,
        IUserService userService)
    {
        _mediator = mediator;
        _userService = userService;
    }

    [HttpGet("{role}")]
    public async Task<ActionResult<IEnumerable<Employee>>> GetByRole(Role role)
    {
        var users = await _mediator.Send(new GetAllUsersWithGivenRoleQuery(role));
        return Ok(users);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Register(RegisterNewUserCommand request)
    {
        var userId = await _mediator.Send(request);
        return Ok(new { id = userId });
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(string id)
    {
        var command = new DeleteUserCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{email}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    [HttpPut]
    public async Task<IActionResult> ChangeEmail(UpdateUserEmailCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
