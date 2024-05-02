using CustomersManagement.UI.Models.Shared;
using CustomersManagement.UI.Models.TravelAgency;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ITourService
{
    Task<List<ActivityVM>> GetAllTours();
    Task<TourDetailsVM> GetTourDetails(int id);
    Task<Response<Guid>> CreateTour(TourDetailsVM tour);
    Task<Response<Guid>> UpdateTour(int id, TourDetailsVM tour);
    Task<Response<Guid>> DeleteTour(int id);
    Task<List<ActivityParticipantVM>> GetTourParticipants(int tourId);
}
