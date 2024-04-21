namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetAllTravelAgencyCustomers;

public class TravelAgencyCustomerDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string EmailAddress { get; set; } = string.Empty;
}
