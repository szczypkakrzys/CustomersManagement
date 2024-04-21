using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetCustomerTourDetails;

public record GetCustomerTourDetailsQuery(int CustomerId, int TourId) : IRequest<CustomerTourDetailsDto>;
