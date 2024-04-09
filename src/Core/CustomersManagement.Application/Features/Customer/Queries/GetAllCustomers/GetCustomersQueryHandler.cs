using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;

public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, List<CustomerDto>>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IAppLogger<GetCustomersQueryHandler> _logger;

    public GetCustomersQueryHandler(
        IMapper mapper,
        ICustomerRepository customerRepository,
        IAppLogger<GetCustomersQueryHandler> logger)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _logger = logger;
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
