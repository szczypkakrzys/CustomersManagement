using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Domain.Notification;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Contracts.Notifications;

public interface INotificationService
{
    List<Notification> ProcessCustomersBirthdaysNotifications(List<string> customers, NotificationType type, DateOnly date);
    List<Notification> ProcessToursNotifications(List<Tour> tours, DateOnly date);
    List<Notification> ProcessCoursesNotifications(List<DivingCourse> courses, DateOnly date);
    Task CreateNotifications(List<Notification> notificationsList);
}
