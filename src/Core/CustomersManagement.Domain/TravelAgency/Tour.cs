using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class Tour : CustomerActivity
{
    public ICollection<TravelAgencyCustomer> Participants { get; set; } = new List<TravelAgencyCustomer>();
    public ICollection<CustomersToursRelations> TourRelations { get; set; } = new List<CustomersToursRelations>();
}
