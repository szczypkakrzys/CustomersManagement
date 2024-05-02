using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetAllDivingSchoolCustomers;

public record GetDivingSchoolCustomersQuery : IRequest<IEnumerable<DivingSchoolCustomerDto>>;
