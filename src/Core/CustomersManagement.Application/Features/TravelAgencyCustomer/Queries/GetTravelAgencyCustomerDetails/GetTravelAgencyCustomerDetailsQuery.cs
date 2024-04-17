using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;

public record GetTravelAgencyCustomerDetailsQuery(int Id) : IRequest<TravelAgencyCustomerDetailsDto>;
