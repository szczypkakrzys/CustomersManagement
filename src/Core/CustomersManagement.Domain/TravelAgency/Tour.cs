using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class Tour : BaseEntity
{
    public ICollection<TravelAgencyCustomer> Participants { get; set; }
    public ICollection<CustomersToursRelations> TourRelations { get; set; }
}
