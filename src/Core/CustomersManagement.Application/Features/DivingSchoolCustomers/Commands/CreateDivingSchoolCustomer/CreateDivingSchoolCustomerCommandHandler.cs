using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.DivingSchool;
using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Commands.CreateDivingSchoolCustomer;

public class CreateDivingSchoolCustomerCommandHandler : IRequestHandler<CreateDivingSchoolCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IDivingSchoolCustomerRepository _customerRepository;

    public CreateDivingSchoolCustomerCommandHandler(
        IMapper mapper,
        IDivingSchoolCustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(
        CreateDivingSchoolCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateDivingSchoolCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Customer", validationResult);

        var customerToCreate = _mapper.Map<DivingSchoolCustomer>(request);

        await _customerRepository.CreateAsync(customerToCreate);

        return customerToCreate.Id;
    }
}
