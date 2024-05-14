using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Contracts.Notifications;

public interface IEventProcessor
{
    Task<List<Tour>> GetTravelAgencyEventsByDate(DateOnly date);
    Task<List<DivingCourse>> GetDivingSchoolEventsByDate(DateOnly date);
    Task<List<string>> GetTravelAgencyCustomersNamesWithBirthdayOnDate(DateOnly date);
    Task<List<string>> GetDivingSchoolCustomersNamesWithBirthdayOnDate(DateOnly date);
}
