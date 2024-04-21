﻿using FluentValidation;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.UpdateCustomerPayment;

public class UpdateCustomerTourPaymentCommandValidator : AbstractValidator<UpdateCustomerTourPaymentCommand>
{
    public UpdateCustomerTourPaymentCommandValidator(int entireCostLeftToPay)
    {
        RuleFor(p => p.CustomerId)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.TourId)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.PaymentAmount)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.PaymentAmount)
           .LessThanOrEqualTo(entireCostLeftToPay)
               .WithMessage("{PropertyName} can't be greater than amount left to pay.");
    }
}
