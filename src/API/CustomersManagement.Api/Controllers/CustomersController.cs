using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Application.Features.Customer.Commands.DeleteCustomer;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cutomers.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<CustomerDto>>> Get()
    {
        var customers = await _mediator.Send(new GetCustomersQuery());
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CustomerDetailsDto>> Get(int id)
    {
        var customerDetails = await _mediator.Send(new GetCustomerDetailsQuery(id));
        return Ok(customerDetails);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post(CreateCustomerCommand customer)
    {
        var response = await _mediator.Send(customer);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateCustomerCommand customer)
    {
        await _mediator.Send(customer);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCustomerCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }
}
