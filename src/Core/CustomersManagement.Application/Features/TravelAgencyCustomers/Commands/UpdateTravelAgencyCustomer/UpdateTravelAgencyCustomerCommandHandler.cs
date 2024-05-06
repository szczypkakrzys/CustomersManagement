using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.UpdateTravelAgencyCustomer;

public class UpdateTravelAgencyCustomerCommandHandler : IRequestHandler<UpdateTravelAgencyCustomerCommand, Unit>
{
    private readonly IMapper _mapper;
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public UpdateTravelAgencyCustomerCommandHandler(
        IMapper mapper,
        ITravelAgencyCustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<Unit> Handle(
        UpdateTravelAgencyCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new UpdateTravelAgencyCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid customer data", validationResult);

        var customerToUpdate = _mapper.Map<TravelAgencyCustomer>(request);

        await _customerRepository.UpdateAsync(customerToUpdate);

        return Unit.Value;
    }
}
