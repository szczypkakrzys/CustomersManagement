﻿namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetAllCustomerTours;

public class CustomerTourDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateOnly TimeStart { get; set; }
    public DateOnly TimeEnd { get; set; }
}
