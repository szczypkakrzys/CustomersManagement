using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;
    private readonly IAppLogger<UpdateCustomerCommandHandler> _logger;

    public UpdateCustomerCommandHandler(
        IMapper mapper,
        ICustomerRepository customerRepository,
        IAppLogger<UpdateCustomerCommandHandler> logger)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<Unit> Handle(
        UpdateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
        {
            _logger.LogError("Validation erros in update request for {Customer} - {Id}: {Errors}", nameof(Customer), request.Id, validationResult.Errors);
            throw new BadRequestException("Invalid customer data", validationResult);
        }

        var customerToUpdate = _mapper.Map<Domain.Customer>(request);

        await _customerRepository.UpdateAsync(customerToUpdate);

        return Unit.Value;
    }
}
