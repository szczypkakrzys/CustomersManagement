using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Application.Features.Documents.Enums;
using CustomersManagement.Domain;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class DocumentRepository : GenericRepository<Document>, IDocumentRepository
{
    public DocumentRepository(ClientsDatabaseContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Document>> GetAllDocumentsTemplates()
    {
        return await _context.Documents
            .Where(property => property.Type == DocumentType.Template.ToString())
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Document>> GetCustomerDocumentsAsync(int customerId)
    {
        return await _context.Documents
            .Where(
            property =>
                property.Type == DocumentType.Template.ToString()
                &&
                property.ClientId == customerId)
            .ToListAsync();
    }
}
