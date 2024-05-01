using CustomersManagement.Application.Features.Tours.Commands.CreateTour;
using CustomersManagement.Application.Features.Tours.Commands.DeleteTour;
using CustomersManagement.Application.Features.Tours.Commands.UpdateTour;
using CustomersManagement.Application.Features.Tours.Queries.GetAllTourParticipants;
using CustomersManagement.Application.Features.Tours.Queries.GetAllTours;
using CustomersManagement.Application.Features.Tours.Queries.GetTourDetails;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CustomersManagement.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ToursController : Controller
{
    private readonly IMediator _mediator;

    public ToursController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TourDto>>> Get()
    {
        var tours = await _mediator.Send(new GetToursQuery());
        return Ok(tours);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TourDetailsDto>> Get(int id)
    {
        var tourDetails = await _mediator.Send(new GetTourDetailsQuery(id));
        return Ok(tourDetails);
    }

    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Post(CreateTourCommand tour)
    {
        var response = await _mediator.Send(tour);
        return CreatedAtAction(nameof(Get), new { id = response });
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Put(UpdateTourCommand tour)
    {
        await _mediator.Send(tour);
        return NoContent();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(400)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTourCommand { Id = id };
        await _mediator.Send(command);
        return NoContent();
    }

    [HttpGet("{id}/participants")]
    public async Task<ActionResult<IEnumerable<TourParticipantDto>>> GetTourParticipants(int id)
    {
        var participants = await _mediator.Send(new GetTourParticipantsQuery(id));
        return Ok(participants);
    }
}
