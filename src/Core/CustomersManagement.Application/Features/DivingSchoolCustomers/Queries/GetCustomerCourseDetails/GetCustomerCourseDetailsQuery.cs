﻿using MediatR;

namespace CustomersManagement.Application.Features.DivingSchoolCustomers.Queries.GetCustomerCourseDetails;

public record GetCustomerCourseDetailsQuery(int customerId, int courseId) : IRequest<CustomerCourseDetailsDto>;
