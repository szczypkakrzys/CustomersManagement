﻿using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CreateCustomerCommandHandler(
        IMapper mapper,
        ICustomerRepository customerRepository)
    {
        _mapper = mapper;
        _customerRepository = customerRepository;
    }

    public async Task<int> Handle(
        CreateCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var validator = new CreateCustomerCommandValidator(_customerRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid Customer", validationResult);

        var customerToCreate = _mapper.Map<Domain.Customer>(request);

        await _customerRepository.CreateAsync(customerToCreate);

        return customerToCreate.Id;
    }
}
