﻿using CustomersManagement.Application.Models.Identity;
using MediatR;

namespace CustomersManagement.Application.Features.SystemUsers.Queries;

public record GetAllUsersWithGivenRoleQuery(Role Role) : IRequest<IEnumerable<Employee>>;