using CustomersManagement.UI.Models.Shared;

namespace CustomersManagement.UI.Models.TravelAgencyCustomers;

public class TravelAgencyCustomerDetailsVM
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
    public AddressVM Address { get; set; }
}
