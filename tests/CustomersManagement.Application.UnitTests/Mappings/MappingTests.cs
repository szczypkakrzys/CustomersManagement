using AutoMapper;
using CustomersManagement.Application.Features.Customer.Commands.CreateCustomer;
using CustomersManagement.Application.Features.Customer.Commands.UpdateCustomer;
using CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;
using CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;
using CustomersManagement.Application.Features.Shared;
using CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.CreateTravelAgencyCustomer;
using CustomersManagement.Application.MappingProfiles;
using CustomersManagement.Domain;
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
            cfg.AddProfile<TravelAgencyCustomerProfile>();
        });

        _mapper = _configuration.CreateMapper();
    }

    [Fact]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Theory]
    [InlineData(typeof(TravelAgencyCustomer), typeof(TravelAgencyCustomerDto))]
    [InlineData(typeof(TravelAgencyCustomer), typeof(TravelAgencyCustomerDetailsDto))]
    [InlineData(typeof(TravelAgencyCustomerDetailsDto), typeof(TravelAgencyCustomer))]
    [InlineData(typeof(CreateTravelAgencyCustomerCommand), typeof(TravelAgencyCustomer))]
    [InlineData(typeof(UpdateTravelAgencyCustomerCommand), typeof(TravelAgencyCustomer))]
    [InlineData(typeof(DateTime), typeof(DateOnly))]
    [InlineData(typeof(Address), typeof(AddressDto))]
    [InlineData(typeof(AddressDto), typeof(Address))]
    [InlineData(typeof(CreateAddressDto), typeof(Address))]
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
