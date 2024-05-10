using AutoMapper;
using CustomersManagement.Application.Contracts.Identity;
using CustomersManagement.Application.Contracts.Notifications;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Models.Identity;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Domain.Notification;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Services;
public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public NotificationService(
        INotificationRepository notificationRepository,
        IUserService userService,
        IMapper mapper)
    {
        _notificationRepository = notificationRepository;
        _userService = userService;
        _mapper = mapper;
    }

    //TODO
    //add users to Id's collection - create one notification with 'Birthday' message and users collection in Id's 
    public List<Notification> ProcessCustomersBirthdaysNotifications(List<string> customers, NotificationType type)
    {
        List<Notification> notificationsList = [];

        foreach (var customer in customers)
        {
            var notification = new Notification
            {
                Message = "Birthday:" + customer,
                Type = type,
            };

            notificationsList.Add(notification);
        }

        return notificationsList;
    }

    public List<Notification> ProcessToursNotifications(List<Tour> tours, DateOnly date)
    {
        var notificationsList = new List<Notification>();

        foreach (var tour in tours)
        {
            if (tour.AdvancePaymentDeadline == date)
            {
                var overduePayments = tour.TourRelations.Where(cost => cost.AdvancedPaymentLeftToPay != 0).ToList();

                var customersIdsList = GetTourUsersIds(overduePayments);

                notificationsList.Add(CreateActivityPaymentNotification("Advance Payment",
                                                                        NotificationType.TravelAgency,
                                                                        tour.Id,
                                                                        customersIdsList));
            }
            else if (tour.EntireAmountPaymentDeadline == date)
            {
                var overduePayments = tour.TourRelations.Where(cost => cost.EntireCostLeftToPay != 0).ToList();
                var customersIdsList = GetTourUsersIds(overduePayments);

                notificationsList.Add(CreateActivityPaymentNotification("Entire Payment",
                                                                        NotificationType.TravelAgency,
                                                                        tour.Id,
                                                                        customersIdsList));
            }
            else if (tour.TimeStart == date)
            {
                notificationsList.Add(
                    CreateActivityDateNotification("Time Start",
                                                   NotificationType.TravelAgency,
                                                   tour.Id));
            }
            else if (tour.TimeEnd == date)
            {
                notificationsList.Add(
                    CreateActivityDateNotification("Time End",
                                                   NotificationType.TravelAgency,
                                                   tour.Id));
            }
        }

        return notificationsList;
    }

    public List<Notification> ProcessCoursesNotifications(List<DivingCourse> courses, DateOnly date)
    {
        var notificationsList = new List<Notification>();

        foreach (var course in courses)
        {
            if (course.AdvancePaymentDeadline == date)
            {
                var overduePayments = course.DivingCourseRelations.Where(cost => cost.AdvancedPaymentLeftToPay != 0).ToList();

                var customersIdsList = GetCoursesUsersIds(overduePayments);

                notificationsList.Add(CreateActivityPaymentNotification("Advance Payment",
                                                                        NotificationType.DivingSchool,
                                                                        course.Id,
                                                                        customersIdsList));
            }
            else if (course.EntireAmountPaymentDeadline == date)
            {
                var overduePayments = course.DivingCourseRelations.Where(cost => cost.EntireCostLeftToPay != 0).ToList();

                var customersIdsList = GetCoursesUsersIds(overduePayments);

                notificationsList.Add(CreateActivityPaymentNotification("Entire Payment",
                                                                        NotificationType.DivingSchool,
                                                                        course.Id,
                                                                        customersIdsList));
            }
            else if (course.TimeStart == date)
            {
                notificationsList.Add(
                    CreateActivityDateNotification("Time Start",
                                                   NotificationType.DivingSchool,
                                                   course.Id));
            }
            else if (course.TimeEnd == date)
            {
                notificationsList.Add(
                    CreateActivityDateNotification("Time End",
                                                   NotificationType.DivingSchool,
                                                   course.Id));
            }
        }

        return notificationsList;
    }

    private static List<int> GetTourUsersIds(List<CustomersToursRelations> toursRelations)
    {
        var customersIdsList = new List<int>();
        foreach (var relation in toursRelations)
        {
            customersIdsList.Add(relation.CustomerId);
        }
        return customersIdsList;
    }

    public async Task CreateNotifications(List<Notification> notificationsList)
    {
        var (travelAgencyReceiversIds, divingSchoolReceiversIds) = await GetNotificationsReceivers();

        foreach (var notification in notificationsList)
        {
            IEnumerable<string> receiversIds = notification.Type switch
            {
                NotificationType.TravelAgency => travelAgencyReceiversIds,
                NotificationType.DivingSchool => divingSchoolReceiversIds,
                _ => throw new InvalidOperationException($"Unknown notification type: {notification.Type}")
            };

            await CreateNotificationsForType(notification, receiversIds);
        }
    }

    private async Task CreateNotificationsForType(Notification notification, IEnumerable<string> receiversIds)
    {
        foreach (var userId in receiversIds)
        {
            var newNotification = _mapper.Map<Notification>(notification);
            newNotification.ApplicationUserId = userId;
            await _notificationRepository.CreateAsync(newNotification);
        }
    }

    private async Task<(IEnumerable<string> travelAgencyReceiversIds, IEnumerable<string> divingSchoolReceiversIds)> GetNotificationsReceivers()
    {
        var admins = await _userService.GetEmployeesByRole(RoleName.Administrator);
        var travelAgencyEmployees = await _userService.GetEmployeesByRole(RoleName.TravelAgencyEmployee);
        var DivingSchoolEmployees = await _userService.GetEmployeesByRole(RoleName.DivingSchoolEmployee);

        IEnumerable<string> travelAgencyNotificationsAllowedUsersIds =
        travelAgencyEmployees.Select(employee => employee.Id).Concat(admins.Select(admin => admin.Id));

        IEnumerable<string> divingSchoolNotificationsAllowedUsersIds =
       DivingSchoolEmployees.Select(employee => employee.Id).Concat(admins.Select(admin => admin.Id));

        return (travelAgencyNotificationsAllowedUsersIds, divingSchoolNotificationsAllowedUsersIds);
    }

    private static List<int> GetCoursesUsersIds(List<CustomersDivingCoursesRelations> coursesRelations)
    {
        var customersIdsList = new List<int>();
        foreach (var relation in coursesRelations)
        {
            customersIdsList.Add(relation.CustomerId);
        }
        return customersIdsList;
    }

    private Notification CreateActivityPaymentNotification(string message, NotificationType type, int activityId, List<int> customersIdsList)
    {
        return new Notification
        {
            Message = message,
            Type = type,
            ActivityId = activityId,
            CustomersIdsList = customersIdsList
        };
    }

    private Notification CreateActivityDateNotification(string message, NotificationType type, int activityId)
    {
        return new Notification
        {
            Message = message,
            Type = type,
            ActivityId = activityId
        };
    }
}