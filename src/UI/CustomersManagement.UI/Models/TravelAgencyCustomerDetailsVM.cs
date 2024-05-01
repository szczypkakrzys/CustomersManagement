using CustomersManagement.UI.Models.Shared;

namespace CustomersManagement.UI.Models;

public class TravelAgencyCustomerDetailsVM : CustomerVM
{
    public int Id { get; set; }
    public AddressVM Address { get; set; }
}
