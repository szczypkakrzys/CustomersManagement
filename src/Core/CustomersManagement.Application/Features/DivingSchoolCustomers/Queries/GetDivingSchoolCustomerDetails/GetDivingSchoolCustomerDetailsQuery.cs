using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetDivingSchoolCustomerDetails;

public record GetDivingSchoolCustomerDetailsQuery(int Id) : IRequest<DivingSchoolCustomerDetailsDto>;
