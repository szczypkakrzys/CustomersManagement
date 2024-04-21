using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetCustomerTourDetails;

public class GetCustomerTourDetailsQueryHandler : IRequestHandler<GetCustomerTourDetailsQuery, CustomerTourDetailsDto>
{
    private readonly ICustomersToursRelationsRepository _relationsRepository;
    private readonly IMapper _mapper;

    public GetCustomerTourDetailsQueryHandler(
        ICustomersToursRelationsRepository relationsRepository,
        IMapper mapper)
    {
        _relationsRepository = relationsRepository;
        _mapper = mapper;
    }

    public async Task<CustomerTourDetailsDto> Handle(
        GetCustomerTourDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var details = await _relationsRepository.GetCustomerTourDetails(request.CustomerId, request.TourId) ??
             throw new NotFoundException($"Relation with customerId: {request.CustomerId} and tourId:", request.TourId);

        var data = _mapper.Map<CustomerTourDetailsDto>(details);

        return data;
    }
}
