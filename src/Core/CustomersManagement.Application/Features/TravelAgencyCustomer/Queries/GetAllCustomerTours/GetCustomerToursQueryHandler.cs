using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetAllCustomerTours;

public class GetCustomerToursQueryHandler : IRequestHandler<GetCustomerToursQuery, IEnumerable<CustomerTourDto>>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerToursQueryHandler(
        ITravelAgencyCustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerTourDto>> Handle(
        GetCustomerToursQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdWithTours(request.Id) ??
            throw new NotFoundException(nameof(TravelAgencyCustomer), request.Id);

        var result = _mapper.Map<IEnumerable<CustomerTourDto>>(customer.Tours);

        return result;
    }
}
