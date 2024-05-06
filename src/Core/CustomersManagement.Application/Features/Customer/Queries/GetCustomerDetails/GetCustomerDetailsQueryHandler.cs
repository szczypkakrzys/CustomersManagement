using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;

public class GetCustomerDetailsQueryHandler : IRequestHandler<GetCustomerDetailsQuery, CustomerDetailsDto>
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    public GetCustomerDetailsQueryHandler(
        ICustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<CustomerDetailsDto> Handle(
        GetCustomerDetailsQuery request,
        CancellationToken cancellationToken)
    {
        var customerDetails = await _customerRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Customer), request.Id);

        var data = _mapper.Map<CustomerDetailsDto>(customerDetails);

        return data;
    }
}
