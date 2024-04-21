using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetAllTravelAgencyCustomers;

public record GetTravelAgencyCustomersQuery : IRequest<List<TravelAgencyCustomerDto>>;