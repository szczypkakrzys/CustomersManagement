using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetTravelAgencyCustomerDetails;

public class GetTravelAgencyCustomerDetailsQueryHandler : IRequestHandler<GetTravelAgencyCustomerDetailsQuery, TravelAgencyCustomerDetailsDto>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetTravelAgencyCustomerDetailsQueryHandler(
        ITravelAgencyCustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<TravelAgencyCustomerDetailsDto> Handle(
        GetTravelAgencyCustomerDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var customerDetails = await _customerRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(TravelAgencyCustomer), request.Id);

        var data = _mapper.Map<TravelAgencyCustomerDetailsDto>(customerDetails);

        return data;
    }
}
