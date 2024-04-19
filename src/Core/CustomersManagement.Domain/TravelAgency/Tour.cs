using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class Tour : CustomerActivity
{
    public ICollection<TravelAgencyCustomer> Participants { get; set; }
    public ICollection<CustomersToursRelations> TourRelations { get; set; }
}
