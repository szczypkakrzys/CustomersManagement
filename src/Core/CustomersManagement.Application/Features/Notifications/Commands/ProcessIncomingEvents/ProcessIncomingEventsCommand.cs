using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Commands.ProcessIncomingEvents;

public class ProcessIncomingEventsCommand : IRequest<Unit>
{
    public DateTime EventsDate { get; set; }
}
