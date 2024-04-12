using AutoMapper;
using CustomersManagement.Application.Contracts.Logging;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using FluentAssertions;
using NSubstitute;


namespace CustomersManagement.Application.UnitTests.Features.Customer.Queries;

public class GetAllCustomersTests
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly GetCustomersQueryHandler _handler;
    private readonly IAppLogger<GetCustomersQueryHandler> _logger;

    public GetAllCustomersTests()
    {
        _customerRepository = Substitute.For<ICustomerRepository>();
        _mapper = Substitute.For<IMapper>();
        _logger = Substitute.For<IAppLogger<GetCustomersQueryHandler>>();
        _handler = new GetCustomersQueryHandler(_mapper, _customerRepository, _logger);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ReturnsListOfCustomerDto()
    {
        // Arrange
        var request = new GetCustomersQuery();
        var customers = new List<Domain.Customer>();
        var expected = new List<CustomerDto>()
        {
            new()
            {
                Id = 1,
                FirstName = "Customer1FirstName",
                LastName = "Customer1LastName",
            },
            new()
            {
                Id = 2,
                FirstName = "Customer2FirstName",
                LastName = "Customer2LastName",
            }
        };

        _customerRepository.GetAsync().Returns(customers);
        _mapper.Map<List<CustomerDto>>(customers).Returns(expected);

        // Act
        var result = await _handler.Handle(request, CancellationToken.None);

        // Assert
        result.Should().BeEquivalentTo(expected);
    }
}
