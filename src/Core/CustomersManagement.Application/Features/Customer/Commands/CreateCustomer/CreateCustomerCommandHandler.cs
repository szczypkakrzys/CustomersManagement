using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAppLogger<CreateCustomerCommandHandler> _logger;

    public CreateCustomerCommandHandler(
        IMapper mapper,
        ICustomerRepository customerRepository,
        IAppLogger<CreateCustomerCommandHandler> logger)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<int> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator(_customerRepository);
        var validtionResult = await validator.ValidateAsync(request);

        if (validtionResult.Errors.Any())
        {
            _logger.LogWarning("Validation erros in create request for {0}", nameof(Customer));
            throw new BadRequestException("Invalid Customer", validtionResult);
        }

        var customerToCreate = _mapper.Map<Domain.Customer>(request);

        await _customerRepository.CreateAsync(customerToCreate);

        return customerToCreate.Id;
    }
}
