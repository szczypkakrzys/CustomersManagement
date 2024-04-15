using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Domain.TravelAgency;
using FluentAssertions;
using FluentValidation.TestHelper;
using MediatR;
using NSubstitute;

namespace CustomersManagement.Application.UnitTests.Features.Customer.Commands;

public class UpdateCustomerTests
{
    private readonly IMapper _mapper;
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly UpdateCustomerCommandValidator _validator;
    private readonly UpdateCustomerCommandHandler _handler;

    public UpdateCustomerTests()
    {
        _mapper = Substitute.For<IMapper>();
        _customerRepository = Substitute.For<ITravelAgencyCustomerRepository>();
        _validator = new UpdateCustomerCommandValidator(_customerRepository);
        _handler = new UpdateCustomerCommandHandler(_mapper, _customerRepository);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsCreatedCustomerId()
    {
        // Arrange
        var customerId = 1;
        var request = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "test@customer.com"
        };

        var customerToUpdate = new TravelAgencyCustomer();

        _customerRepository.IsCustomerUnique(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);
        _customerRepository.GetByIdAsync(customerId).Returns(customerToUpdate);
        _customerRepository.UpdateAsync(customerToUpdate).Returns(Task.CompletedTask);
        _mapper.Map<TravelAgencyCustomer>(request).Returns(customerToUpdate);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().Be(Unit.Value);
    }

    [Fact]
    public async Task Validate_WithNonexistentCustomerId_ThrowsBadRequestExceptionAndShouldHaveIdValidationError()
    {
        // Arrange
        var customerId = 1;
        var request = new UpdateCustomerCommand
        {
            Id = customerId,
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "test@customer.com"
        };

        var customerToUpdate = new TravelAgencyCustomer();

        _customerRepository.GetByIdAsync(customerId).Returns(default(TravelAgencyCustomer));

        // Act
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
           .WithMessage("Invalid customer data");

        await _customerRepository.DidNotReceive().UpdateAsync(Arg.Any<TravelAgencyCustomer>());

        result.ShouldHaveValidationErrorFor(request => request.Id)
            .WithErrorMessage($"Couldn't find customer with Id = {request.Id}");
    }

    [Fact]
    public async Task Validate_CustomerDataIsEmpty_ThrowsBadRequestExceptionAndShouldHaveValidationErrors()
    {
        // Arrange
        var request = new UpdateCustomerCommand();

        // Act 
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
           .WithMessage("Invalid customer data");

        await _customerRepository.DidNotReceive().UpdateAsync(Arg.Any<TravelAgencyCustomer>());

        result.ShouldHaveValidationErrorFor(request => request.Id)
            .WithErrorMessage("Id is required");
        result.ShouldHaveValidationErrorFor(request => request.FirstName)
            .WithErrorMessage("First Name is required");
        result.ShouldHaveValidationErrorFor(request => request.LastName)
            .WithErrorMessage("Last Name is required");
        result.ShouldHaveValidationErrorFor(request => request.EmailAddress)
            .WithErrorMessage("Email Address is required");
    }

    [Fact]
    public async Task Validate_EmailAddressHasIncorrectFormat_ThrowsBadRequestExceptionAndShouldHaveEmailValidationError()
    {
        // Arrange
        var customerId = 1;
        var request = new UpdateCustomerCommand
        {
            Id = 1,
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "testcustomercom"
        };

        var customerToUpdate = new TravelAgencyCustomer();

        _customerRepository.IsCustomerUnique(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);
        _customerRepository.GetByIdAsync(customerId).Returns(customerToUpdate);

        // Act
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
           .WithMessage("Invalid customer data");

        await _customerRepository.DidNotReceive().UpdateAsync(Arg.Any<TravelAgencyCustomer>());

        result.ShouldHaveValidationErrorFor(request => request.EmailAddress)
            .WithErrorMessage($"{request.EmailAddress} is not a valid Email");
    }
}
