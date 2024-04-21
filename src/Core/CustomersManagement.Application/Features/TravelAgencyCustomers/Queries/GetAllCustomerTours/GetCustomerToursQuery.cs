using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomers.Queries.GetAllCustomerTours;

public record GetCustomerToursQuery(int Id) : IRequest<IEnumerable<CustomerTourDto>>;