using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.CreateTravelAgencyCustomer;

public class CreateTravelAgencyCustomerCommandHandler : IRequestHandler<CreateTravelAgencyCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public CreateTravelAgencyCustomerCommandHandler(
        IMapper mapper,
        ITravelAgencyCustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(
        CreateTravelAgencyCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateTravelAgencyCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Customer", validationResult);

        var customerToCreate = _mapper.Map<Domain.TravelAgency.TravelAgencyCustomer>(request);

        await _customerRepository.CreateAsync(customerToCreate);

        return customerToCreate.Id;
    }
}
