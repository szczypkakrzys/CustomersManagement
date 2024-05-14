using CustomersManagement.Application.Contracts.Notifications;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.Common;
using CustomersManagement.Domain.DivingSchool;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.Services;

public class EventProcessorService : IEventProcessor
{
    private readonly ITravelAgencyCustomerRepository _travelAgencyCustomerRepository;
    private readonly ITourRepository _tourRepository;
    private readonly IDivingSchoolCustomerRepository _divingSchoolCustomerRepository;
    private readonly IDivingCourseRepository _divingCourseRepository;

    public EventProcessorService(
        ITravelAgencyCustomerRepository travelAgencyCustomerRepository,
        ITourRepository tourRepository,
        IDivingSchoolCustomerRepository divingSchoolCustomerRepository,
        IDivingCourseRepository divingCourseRepository)
    {
        _travelAgencyCustomerRepository = travelAgencyCustomerRepository;
        _tourRepository = tourRepository;
        _divingSchoolCustomerRepository = divingSchoolCustomerRepository;
        _divingCourseRepository = divingCourseRepository;
    }

    public async Task<List<Tour>> GetTravelAgencyEventsByDate(DateOnly date)
    {
        return await _tourRepository.GetToursWithRelationsByDate(date);
    }

    public async Task<List<DivingCourse>> GetDivingSchoolEventsByDate(DateOnly date)
    {
        return await _divingCourseRepository.GetCoursesWithRelationsByDate(date);
    }

    public async Task<List<string>> GetTravelAgencyCustomersNamesWithBirthdayOnDate(DateOnly date)
    {
        var customers = await _travelAgencyCustomerRepository.GetCustomersByDateOfBirth(date);

        return ExtractCustomersNames(customers);
    }

    public async Task<List<string>> GetDivingSchoolCustomersNamesWithBirthdayOnDate(DateOnly date)
    {
        var customers = await _divingSchoolCustomerRepository.GetCustomersByDateOfBirth(date);

        return ExtractCustomersNames(customers);
    }

    public List<string> ExtractCustomersNames(IEnumerable<Customer> customers)
    {
        List<string> result = [];
        foreach (var customer in customers)
        {
            result.Add(customer.FirstName + " " + customer.LastName);
        }
        return result;
    }
}
