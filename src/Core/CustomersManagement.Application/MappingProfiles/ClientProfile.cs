using AutoMapper;
using CustomersManagement.Application.Features.Client.Commands.CreateClient;
using CustomersManagement.Application.Features.Client.Commands.UpdateClient;
using CustomersManagement.Application.Features.Client.Queries.GetAllClients;
using CustomersManagement.Application.Features.Client.Queries.GetClientDetails;
using CustomersManagement.Domain;

namespace CustomersManagement.Application.MappingProfiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            //todo
            //check whether I need two ways mapping
            CreateMap<ClientDto, Client>().ReverseMap();
            CreateMap<ClientDetailsDto, Client>().ReverseMap();
            CreateMap<CreateClientCommand, Client>();
            CreateMap<UpdateClientCommand, Client>();

        }
    }
}
