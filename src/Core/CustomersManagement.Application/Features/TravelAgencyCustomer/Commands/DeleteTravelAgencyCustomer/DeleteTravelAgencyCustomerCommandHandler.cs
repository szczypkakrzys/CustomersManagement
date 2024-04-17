using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteTravelAgencyCustomerCommandHandler : IRequestHandler<DeleteTravelAgencyCustomerCommand, Unit>
{
    private readonly ITravelAgencyCustomerRepository _customerRepository;

    public DeleteTravelAgencyCustomerCommandHandler(ITravelAgencyCustomerRepository customer) =>
        _customerRepository = customer;

    public async Task<Unit> Handle(
        DeleteTravelAgencyCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customerToDelete = await _customerRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(TravelAgencyCustomer), request.Id);

        await _customerRepository.DeleteAsync(customerToDelete);

        return Unit.Value;
    }
}
