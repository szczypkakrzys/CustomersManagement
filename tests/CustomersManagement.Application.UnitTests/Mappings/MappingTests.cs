using AutoMapper;
using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using CustomersManagement.Application.MappingProfiles;
using CustomersManagement.Domain.TravelAgency;
using System.Runtime.CompilerServices;

namespace CustomersManagement.Application.UnitTests.Mappings;

public class MappingTests
{
    private readonly MapperConfiguration _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile<CustomerProfile>();
        });

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(TravelAgencyCustomer), typeof(CustomerDto))]
    [InlineData(typeof(TravelAgencyCustomer), typeof(CustomerDetailsDto))]
    [InlineData(typeof(CustomerDetailsDto), typeof(TravelAgencyCustomer))]
    [InlineData(typeof(CreateCustomerCommand), typeof(TravelAgencyCustomer))]
    [InlineData(typeof(UpdateCustomerCommand), typeof(TravelAgencyCustomer))]
    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private static object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        return RuntimeHelpers.GetUninitializedObject(type);
    }
}
