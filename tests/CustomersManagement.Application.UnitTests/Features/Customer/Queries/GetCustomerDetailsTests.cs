using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using FluentAssertions;
using NSubstitute;

namespace CustomersManagement.Application.UnitTests.Features.Customer.Queries;

public class GetCustomerDetailsTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly GetCustomerDetailsQueryHandler _handler;

    public GetCustomerDetailsTests()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new GetCustomerDetailsQueryHandler(_customerRepository, _mapper);
    }

    [Fact]
    public async Task Handle_WithExisingId_ReturnsCustomerDetailsDto()
    {
        // Arrange
        var customerId = 1;
        var request = new GetCustomerDetailsQuery(customerId);
        var customerDetails = new Domain.Customer { Id = customerId };
        var customerDetailsDto = new CustomerDetailsDto
        {
            Id = customerId,
            FirstName = "CustomerFirstName",
            LastName = "CustomerLastaName",
            EmailAddress = "customer@email.com"
        };

        _customerRepository.GetByIdAsync(customerId).Returns(customerDetails);
        _mapper.Map<CustomerDetailsDto>(customerDetails).Returns(customerDetailsDto);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(customerDetailsDto);
    }

    [Fact]
    public async Task Handle_WithNonexistentCustomerId_ThrowsNotFoundException()
    {
        // Arrange
        var customerId = 999;
        var request = new GetCustomerDetailsQuery(customerId);

        _customerRepository.GetByIdAsync(customerId).Returns(default(Domain.Customer));

        // Act
        Func<Task> act = async () => await _handler.Handle(request, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<NotFoundException>()
            .WithMessage($"{nameof(Domain.Customer)} ({customerId}) was not found");
    }
}
