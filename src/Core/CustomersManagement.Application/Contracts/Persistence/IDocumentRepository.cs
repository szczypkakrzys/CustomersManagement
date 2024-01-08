using CustomersManagement.Domain;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<IReadOnlyList<Client>> GetCustomerDocumentsAsync(int customerId);
}
