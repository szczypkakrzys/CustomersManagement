namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTours;

public class TourDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly TimeStart { get; set; }
    public DateOnly TimeEnd { get; set; }
}
