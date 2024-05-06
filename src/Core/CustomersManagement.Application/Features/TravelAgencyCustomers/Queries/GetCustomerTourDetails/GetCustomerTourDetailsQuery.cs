using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetCustomerTourDetails;

public record GetCustomerTourDetailsQuery(int customerId, int tourId) : IRequest<CustomerTourDetailsDto>;
