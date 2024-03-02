using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Exceptions;
using MediatR;

namespace CustomersManagement.Application.Features.Customer.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly ICustomerRepository _customerRepository;

    public DeleteCustomerCommandHandler(ICustomerRepository customer) =>
        _customerRepository = customer;

    public async Task<Unit> Handle(
        DeleteCustomerCommand request,
        CancellationToken cancellationToken)
    {
        var customerToDelete = await _customerRepository.GetByIdAsync(request.Id) ??
            throw new NotFoundException(nameof(Customer), request.Id);

        await _customerRepository.DeleteAsync(customerToDelete);

        return Unit.Value;
    }
}
