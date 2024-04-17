﻿namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.CreateTravelAgencyCustomer;

public class CreateAddressDto
{
    public string Country { get; set; }
    public string Voivodeship { get; set; }
    public string PostalCode { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public string HouseNumber { get; set; }
}
