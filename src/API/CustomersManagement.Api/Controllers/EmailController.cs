using CustomersManagement.Application.Features.Emails.Commands.CreateEmailTemplate;
using CustomersManagement.Application.Features.Emails.Commands.DeleteEmailTemplate;
using CustomersManagement.Application.Features.Emails.Commands.SendEmail;
using CustomersManagement.Application.Features.Emails.Queries.GetEmailTemplates;
using CustomersManagement.Domain.Email;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
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

    [HttpPost("{template}")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> PostTemplate(CreateEmailTemplateCommand template)
    {
        var response = await _mediator.Send(template);
        return CreatedAtAction(nameof(GetTemplates), new { id = response });
    }

    [HttpGet("{type}")]
    public async Task<ActionResult<IEnumerable<EmailTemplateDto>>> GetTemplates(EmailType type)
    {
        var emailTemplates = await _mediator.Send(new GetEmailTemplatesQuery(type));
        return Ok(emailTemplates);
    }


    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> DeleteTemplate(int id)
    {
        var command = new DeleteEmailTemplateCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
