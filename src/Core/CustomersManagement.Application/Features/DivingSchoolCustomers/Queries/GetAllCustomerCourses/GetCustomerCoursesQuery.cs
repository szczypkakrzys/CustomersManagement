﻿using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetAllCustomerCourses;

public record GetCustomerCoursesQuery(int Id) : IRequest<IEnumerable<CustomerCourseDto>>;
