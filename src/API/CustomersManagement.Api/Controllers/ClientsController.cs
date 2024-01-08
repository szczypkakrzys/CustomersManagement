using CustomersManagement.Application.Features.Client.Commands.CreateClient;
using CustomersManagement.Application.Features.Client.Commands.DeleteClient;
using CustomersManagement.Application.Features.Client.Commands.UpdateClient;
using CustomersManagement.Application.Features.Client.Queries.GetAllClients;
using CustomersManagement.Application.Features.Client.Queries.GetClientDetails;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Cutomers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ClientsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<UsersController>
    [HttpGet]
    public async Task<List<ClientDto>> Get()
    {
        var users = await _mediator.Send(new GetClientsQuery());
        return users;
    }

    // GET api/<UsersController>/5
    [HttpGet("{id}")]
    public async Task<ClientDetailsDto> Get(int id)
    {
        var userDetails = await _mediator.Send(new GetClientDetailsQuery(id));
        return userDetails;
    }

    // POST api/<UsersController>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post(CreateClientCommand client)
    {
        var response = await _mediator.Send(client);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    // PUT api/<UsersController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateClientCommand client)
    {
        var response = await _mediator.Send(client);
        return NoContent();
    }

    // DELETE api/<UsersController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteClientCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
