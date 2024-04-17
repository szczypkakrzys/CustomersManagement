using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;

public record GetTravelAgencyCustomersQuery : IRequest<List<TravelAgencyCustomerDto>>;