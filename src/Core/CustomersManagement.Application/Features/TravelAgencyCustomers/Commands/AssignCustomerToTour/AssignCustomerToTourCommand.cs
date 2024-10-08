﻿using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Commands.AssignCustomerToTour;

public class AssignCustomerToTourCommand : IRequest<Unit>
{
    public int CustomerId { get; set; }
    public int TourId { get; set; }
}
