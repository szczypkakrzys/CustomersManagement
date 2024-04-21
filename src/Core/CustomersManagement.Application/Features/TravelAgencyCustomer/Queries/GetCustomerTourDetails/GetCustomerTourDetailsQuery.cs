using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetCustomerTourDetails;

public record GetCustomerTourDetailsQuery(int CustomerId, int TourId) : IRequest<CustomerTourDetailsDto>;
