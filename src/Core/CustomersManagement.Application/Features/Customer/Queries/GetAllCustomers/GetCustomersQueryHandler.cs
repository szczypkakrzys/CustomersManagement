using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomersQueryHandler(
        IMapper mapper,
        ITravelAgencyCustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<List<CustomerDto>> Handle(
        GetCustomersQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetAsync();

        var data = _mapper.Map<List<CustomerDto>>(customer);

        return data;
    }
}
