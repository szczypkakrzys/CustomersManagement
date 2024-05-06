using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetAllCustomers;

public record GetCustomersQuery : IRequest<List<CustomerDto>>;