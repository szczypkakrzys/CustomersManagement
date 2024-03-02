using MediatR;

namespace CustomersManagement.Application.Features.Customer.Queries.GetCustomerDetails;

public record GetCustomerDetailsQuery(int Id) : IRequest<CustomerDetailsDto>;
