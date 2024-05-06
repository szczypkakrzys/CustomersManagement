using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.TravelAgency;

public class CustomersToursRelations : CustomersActivitiesRelations
{
    public int CustomerId { get; set; }
    public TravelAgencyCustomer Customer { get; set; }
    public int TourId { get; set; }
    public Tour Tour { get; set; }
}
