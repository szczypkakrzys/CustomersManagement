using AutoMapper;
using CustomersManagement.Application.Features.Tours.Commands.CreateTour;
using CustomersManagement.Application.Features.Tours.Commands.UpdateTour;
using CustomersManagement.Application.Features.Tours.Queries.GetAllTours;
using CustomersManagement.Application.Features.Tours.Queries.GetTourDetails;
using CustomersManagement.Domain.TravelAgency;

namespace CustomersManagement.Application.MappingProfiles;

public class TourProfile : Profile
{
    public TourProfile()
    {
        CreateMap<CreateTourCommand, Tour>()
            .ForMember(dest => dest.Participants, opt => opt.Ignore())
            .ForMember(dest => dest.TourRelations, opt => opt.Ignore())
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<UpdateTourCommand, Tour>()
            .ForMember(dest => dest.Participants, opt => opt.Ignore())
            .ForMember(dest => dest.TourRelations, opt => opt.Ignore())
            .ForMember(dest => dest.TimeCreatedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.TimeLastModifiedInUtc, opt => opt.Ignore())
            .ForMember(dest => dest.LastModifiedBy, opt => opt.Ignore());

        CreateMap<Tour, TourDto>();
        CreateMap<Tour, TourDetailsDto>();
    }
}
