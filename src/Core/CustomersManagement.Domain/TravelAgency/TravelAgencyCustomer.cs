using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class TravelAgencyCustomer : Customer
{
    public ICollection<Tour> Tours { get; set; } = new List<Tour>();
    public ICollection<CustomersToursRelations> ToursRelations { get; set; } = new List<CustomersToursRelations>();
}