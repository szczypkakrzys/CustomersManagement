using MediatR;

namespace CustomersManagement.Application.Features.Tours.Commands.DeleteTour;

public class DeleteTourCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
