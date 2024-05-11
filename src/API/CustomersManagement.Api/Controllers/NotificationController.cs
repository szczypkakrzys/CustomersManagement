using CustomersManagement.Application.Features.Notifications.Commands.DeleteNotification;
using CustomersManagement.Application.Features.Notifications.Commands.ProcessIncomingEvents;
using CustomersManagement.Application.Features.Notifications.Queries.GetUserNotifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class NotificationController : Controller
{
    private readonly IMediator _mediator;

    public NotificationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post(ProcessIncomingEventsCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteNotificationCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{userId}")]
    public async Task<ActionResult<IEnumerable<NotificationDto>>> Get(string userId)
    {
        var userNotifications = await _mediator.Send(new GetUserNotificationsQuery(userId));
        return Ok(userNotifications);
    }
}
