using CustomersManagement.Application.Contracts.Notifications;
using CustomersManagement.Domain.Notification;
using MediatR;

namespace CustomersManagement.Application.Features.Notifications.Commands.ProcessIncomingEvents;

public class ProcessIncomingEventsCommandHandler : IRequestHandler<ProcessIncomingEventsCommand, Unit>
{
    private readonly IEventProcessor _eventProcessor;
    private readonly INotificationService _notificationService;

    public ProcessIncomingEventsCommandHandler(
        IEventProcessor eventProcessor,
        INotificationService notificationService)
    {
        _eventProcessor = eventProcessor;
        _notificationService = notificationService;
    }

    public async Task<Unit> Handle(
        ProcessIncomingEventsCommand request,
        CancellationToken cancellationToken)
    {
        var requestDate = DateOnly.FromDateTime(request.EventsDate);

        var travelAgencyEvents = await _eventProcessor.GetTravelAgencyEventsByDate(requestDate);
        var divingSchoolEvents = await _eventProcessor.GetDivingSchoolEventsByDate(requestDate);

        var travelAgencyCustomersBirthdays = await _eventProcessor.GetTravelAgencyCustomersNamesWithBirthdayOnDate(requestDate);
        var divingSchoolCustomersBirthdays = await _eventProcessor.GetDivingSchoolCustomersNamesWithBirthdayOnDate(requestDate);

        List<Notification> notificationsList = [];

        if (travelAgencyCustomersBirthdays.Count != 0)
        {

            var birthdayNotifications = _notificationService.ProcessCustomersBirthdaysNotifications(
                travelAgencyCustomersBirthdays,
                NotificationType.TravelAgency,
                requestDate);

            notificationsList.AddRange(birthdayNotifications);
        }

        if (divingSchoolCustomersBirthdays.Count != 0)
        {
            var birthdayNotifications = _notificationService.ProcessCustomersBirthdaysNotifications(
                divingSchoolCustomersBirthdays,
                NotificationType.DivingSchool,
                requestDate);

            notificationsList.AddRange(birthdayNotifications);
        }

        if (travelAgencyEvents.Count != 0)
        {
            var eventsNotifications = _notificationService.ProcessToursNotifications(
                travelAgencyEvents,
                requestDate);

            notificationsList.AddRange(eventsNotifications);
        }

        if (divingSchoolEvents.Count != 0)
        {
            var eventsNotifications = _notificationService.ProcessCoursesNotifications(
                divingSchoolEvents,
                requestDate);

            notificationsList.AddRange(eventsNotifications);
        }

        if (notificationsList.Count == 0) return Unit.Value;

        await _notificationService.CreateNotifications(notificationsList);

        return Unit.Value;
    }
}
