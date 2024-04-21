using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Queries.GetAllCustomerTours;

public record GetCustomerToursQuery(int Id) : IRequest<IEnumerable<CustomerTourDto>>;