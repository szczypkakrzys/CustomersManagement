namespace CustomersManagement.Application.Features.Tours.Queries.GetAllTourParticipants;

public class TourParticipantDto
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
