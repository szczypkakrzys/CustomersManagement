using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetTravelAgencyCustomerDetails;

public record GetTravelAgencyCustomerDetailsQuery(int Id) : IRequest<TravelAgencyCustomerDetailsDto>;
