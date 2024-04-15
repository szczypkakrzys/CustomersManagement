using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class TravelAgencyCustomer : Customer
{
    public ICollection<Tour> Tours { get; set; }
    public ICollection<CustomersToursRelations> ToursRelations { get; set; }
}