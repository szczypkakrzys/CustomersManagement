using CustomersManagement.Application.Contracts.Persistence;
using FluentValidation;

namespace CustomersManagement.Application.Features.Tours.Commands.UpdateTour;

public class UpdateTourCommandValidator : AbstractValidator<UpdateTourCommand>
{
    private readonly ITourRepository _tourRepository;

    public UpdateTourCommandValidator(ITourRepository tourRepository)
    {
        RuleFor(p => p.Id)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .MustAsync(TourMustExist)
                .WithMessage("Couldn't find tour with Id = {PropertyValue}");

        RuleFor(p => p.Name)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.TimeStart)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .LessThan(p => p.TimeEnd)
                .WithMessage("TimeStart must be before TimeEnd");

        RuleFor(p => p.TimeEnd)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.EntireCost)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must be greater than or equal to 0");

        RuleFor(p => p.AdvancePaymentCost)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .GreaterThanOrEqualTo(0)
                .WithMessage("{PropertyName} must be greater than or equal to 0");

        RuleFor(p => p.EntireAmountPaymentDeadline)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        RuleFor(p => p.AdvancePaymentDeadline)
            .NotEmpty()
                .WithMessage("{PropertyName} is required")
            .LessThanOrEqualTo(p => p.EntireAmountPaymentDeadline)
                .WithMessage("AdvancePaymentDeadline must be before or the same time as EntireAmountPaymentDeadline")
            .LessThanOrEqualTo(p => p.TimeStart)
                .WithMessage("AdvancePaymentDeadline must be before or the same time as TimeStart");

        RuleFor(p => p.Status)
            .NotEmpty()
                .WithMessage("{PropertyName} is required");

        _tourRepository = tourRepository;
    }

    private async Task<bool> TourMustExist(
        int id,
        CancellationToken token)
    {
        var tour = await _tourRepository.GetByIdAsync(id);
        return tour != null;
    }
}
