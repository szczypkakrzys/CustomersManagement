using CustomersManagement.Domain;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IDocumentRepository : IGenericRepository<Document>
{
    Task<IReadOnlyList<Document>> GetCustomerDocumentsAsync(int customerId);
    Task<IReadOnlyList<Document>> GetAllDocumentsTemplates();
}
