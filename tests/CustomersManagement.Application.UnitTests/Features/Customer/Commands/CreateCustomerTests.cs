using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Domain.TravelAgency;
using FluentAssertions;
using FluentValidation;
using FluentValidation.TestHelper;
using NSubstitute;

namespace CustomersManagement.Application.UnitTests.Features.Customer.Commands;

public class CreateCustomerTests
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly CreateCustomerCommandValidator _validator;
    private readonly IMapper _mapper;
    private readonly CreateCustomerCommandHandler _handler;

    public CreateCustomerTests()
    {
        _customerRepository = Substitute.For<ITravelAgencyCustomerRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new CreateCustomerCommandHandler(_mapper, _customerRepository);
        _validator = new CreateCustomerCommandValidator(_customerRepository);
    }

    [Fact]
    public async Task Handle_ValidRequest_ReturnsCreatedCustomerId()
    {
        // Arrange
        _customerRepository.IsCustomerUnique(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);
        var customerId = 1;
        var customerToCreate = new TravelAgencyCustomer { Id = customerId };

        var request = new CreateCustomerCommand
        {
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "test@customer.com"
        };

        _mapper.Map<TravelAgencyCustomer>(request).Returns(customerToCreate);
        _customerRepository.CreateAsync(customerToCreate).Returns(Task.CompletedTask);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().Be(customerId);
    }

    [Fact]
    public async Task Validate_CustomerDataIsEmpty_ThrowsBadRequestExceptionAndShouldHaveValidationErrors()
    {
        // Arrange
        var request = new CreateCustomerCommand();

        // Act
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
            .WithMessage("Invalid Customer");

        await _customerRepository.DidNotReceive().CreateAsync(Arg.Any<TravelAgencyCustomer>());

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
        _customerRepository.IsCustomerUnique(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(true);

        var request = new CreateCustomerCommand
        {
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "testcustomercom"
        };

        // Act
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
            .WithMessage("Invalid Customer");

        await _customerRepository.DidNotReceive().CreateAsync(Arg.Any<TravelAgencyCustomer>());

        result.ShouldHaveValidationErrorFor(request => request.EmailAddress)
            .WithErrorMessage($"{request.EmailAddress} is not a valid Email");
    }

    [Fact]
    public async Task Validate_CustomerAlreadyExists_ThrowsBadRequestExceptionAndShouldHaveValidationError()
    {
        // Arrange
        _customerRepository.IsCustomerUnique(Arg.Any<string>(), Arg.Any<string>(), Arg.Any<string>()).Returns(false);

        var request = new CreateCustomerCommand
        {
            FirstName = "Test",
            LastName = "Customer",
            EmailAddress = "test@customer.com"
        };

        // Act
        var result = await _validator.TestValidateAsync(request);
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<BadRequestException>()
            .WithMessage("Invalid Customer");

        await _customerRepository.DidNotReceive().CreateAsync(Arg.Any<TravelAgencyCustomer>());

        result.ShouldHaveAnyValidationError()
            .WithErrorMessage("Given customer already exists");
    }
}
