using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;

public class GetTravelAgencyCustomersQueryHandler : IRequestHandler<GetTravelAgencyCustomersQuery, List<TravelAgencyCustomerDto>>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetTravelAgencyCustomersQueryHandler(
        IMapper mapper,
        ITravelAgencyCustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<List<TravelAgencyCustomerDto>> Handle(
        GetTravelAgencyCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync();

        var data = _mapper.Map<List<TravelAgencyCustomerDto>>(customer);

        return data;
    }
}
