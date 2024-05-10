using CustomersManagement.Application.Features.Notifications.Commands.ProcessIncomingEvents;
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
    public async Task<IActionResult> Create(ProcessIncomingEventsCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
