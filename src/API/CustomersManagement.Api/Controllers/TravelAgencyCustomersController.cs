using CustomersManagement.Api.Models;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.AssignCustomerToTour;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.CreateTravelAgencyCustomer;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.DeleteTravelAgencyCustomer;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.RemoveCustomerFromTour;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.UpdateCustomerPayment;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.UpdateTravelAgencyCustomer;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetAllCustomerTours;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetAllTravelAgencyCustomers;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetCustomerTourDetails;
using CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetTravelAgencyCustomerDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cutomers.Api.Controllers;

[Route("api/TravelAgency/Customers/")]
[ApiController]
[Authorize(Policy = Policies.DivingSchool)]
public class TravelAgencyCustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public TravelAgencyCustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<TravelAgencyCustomerDto>>> Get()
    {
        var customers = await _mediator.Send(new GetTravelAgencyCustomersQuery());
        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TravelAgencyCustomerDetailsDto>> Get(int id)
    {
        var customerDetails = await _mediator.Send(new GetTravelAgencyCustomerDetailsQuery(id));
        return Ok(customerDetails);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post(CreateTravelAgencyCustomerCommand customer)
    {
        var response = await _mediator.Send(customer);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateTravelAgencyCustomerCommand customer)
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
        var command = new DeleteTravelAgencyCustomerCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id}/tours")]
    public async Task<ActionResult<IEnumerable<CustomerTourDto>>> GetAllCustomerTours(int id)
    {
        var customerTours = await _mediator.Send(new GetCustomerToursQuery(id));
        return Ok(customerTours);
    }

    [HttpGet("{id}/tour/{tourId}")]
    public async Task<ActionResult<CustomerTourDetailsDto>> GetCustomerTourDetails(int id, int tourId)
    {
        var customerTourDetails = await _mediator.Send(new GetCustomerTourDetailsQuery(id, tourId));
        return Ok(customerTourDetails);
    }

    [HttpPost("{id}/tour/{tourId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AssignCustomerToTour(AssignCustomerToTourCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpPut("{id}/tour/{tourId}/payment")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateCustomerPayment(UpdateCustomerTourPaymentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}/tour/{tourId}/")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RemoveCustomerFromTour(RemoveCustomerFromTourCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}
