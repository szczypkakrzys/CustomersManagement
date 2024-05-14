using CustomersManagement.Application.Features.Emails.Commands.SendEmail;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
//TODO
//authorize with proper roles / policies
public class EmailController : Controller
{
    private readonly IMediator _mediator;

    public EmailController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> SendEmail(SendEmailCommand body)
    {
        var response = await _mediator.Send(body);
        return NoContent();
    }
}
