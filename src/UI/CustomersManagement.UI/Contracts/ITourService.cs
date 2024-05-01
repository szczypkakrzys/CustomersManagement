using CustomersManagement.UI.Models;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface ITourService
{
    Task<List<TourVM>> GetAllTours();
    Task<TourDetailsVM> GetTourDetails(int id);
    Task<Response<Guid>> CreateTour(TourDetailsVM customer);
    Task<Response<Guid>> UpdateTour(int id, TourDetailsVM customer);
    Task<Response<Guid>> DeleteTour(int id);
    Task<List<TourParticipantVM>> GetTourParticipants(int tourId);
}
