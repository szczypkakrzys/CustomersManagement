using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ClientsDatabaseContext context) : base(context)
    {
    }

    public Task<IReadOnlyList<Client>> GetCustomerDocumentsAsync(int customerId)
    {
        throw new NotImplementedException();
    }
}
