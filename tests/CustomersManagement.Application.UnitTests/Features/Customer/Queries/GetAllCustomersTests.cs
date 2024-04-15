using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Domain.TravelAgency;
using FluentAssertions;
using NSubstitute;


namespace CustomersManagement.Application.UnitTests.Features.Customer.Queries;

public class GetAllCustomersTests
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly GetCustomersQueryHandler _handler;

    public GetAllCustomersTests()
    {
        _customerRepository = Substitute.For<ITravelAgencyCustomerRepository>();
        _mapper = Substitute.For<IMapper>();
        _handler = new GetCustomersQueryHandler(_mapper, _customerRepository);
    }

    [Fact]
    public async Task Handle_WithValidRequest_ReturnsListOfCustomerDto()
    {
        // Arrange
        var request = new GetCustomersQuery();
        var customers = new List<TravelAgencyCustomer>();
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
