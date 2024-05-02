using AutoMapper;
using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Domain.TravelAgency;
using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetAllCustomerCourses;

public class GetCustomerCoursesQueryHandler : IRequestHandler<GetCustomerCoursesQuery, IEnumerable<CustomerCourseDto>>
{
    private readonly IDivingSchoolCustomerRepository _customerRepository;
    private readonly IMapper _mapper;

    public GetCustomerCoursesQueryHandler(
        IDivingSchoolCustomerRepository customerRepository,
        IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CustomerCourseDto>> Handle(
        GetCustomerCoursesQuery request,
        CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetByIdWithTours(request.Id) ??
                    throw new NotFoundException(nameof(TravelAgencyCustomer), request.Id);

        var result = _mapper.Map<IEnumerable<CustomerCourseDto>>(customer.DivingCourses);

        return result;
    }
}
