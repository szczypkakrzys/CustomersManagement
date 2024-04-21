using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using CustomersManagement.Application.Services;
using MediatR;

namespace CustomersManagement.Application.Features.TravelAgencyCustomer.Commands.UpdateCustomerPayment;
public class UpdateCustomerTourPaymentCommandHandler : IRequestHandler<UpdateCustomerTourPaymentCommand, Unit>
{
    private readonly ICustomersToursRelationsRepository _relationsRepository;

    public UpdateCustomerTourPaymentCommandHandler(ICustomersToursRelationsRepository relationsRepository) => _relationsRepository = relationsRepository;

    public async Task<Unit> Handle(
        UpdateCustomerTourPaymentCommand request,
        CancellationToken cancellationToken)
    {
        var details = await _relationsRepository.GetCustomerTourDetails(request.CustomerId, request.TourId) ??
           throw new NotFoundException($"Relation with customerId: {request.CustomerId} and tourId:", request.TourId);

        if (details.EntireCostLeftToPay == 0)
            throw new BadRequestException("Tour cost is already paid");

        var validator = new UpdateCustomerTourPaymentCommandValidator(details.EntireCostLeftToPay);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Count != 0)
            throw new BadRequestException("Invalid payment data", validationResult);

        var afterPaymentDetails = PaymentService.RelationAfterPayment(details, request.PaymentAmount);

        await _relationsRepository.UpdateAsync(afterPaymentDetails);

        return Unit.Value;
    }
}
