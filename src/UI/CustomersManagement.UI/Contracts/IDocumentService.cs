using CustomersManagement.UI.Models.Documents;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface IDocumentService
{
    Task<List<DocumentVM>> GetAllDocuments();
    Task<Response<Guid>> GenerateDocument(string fileName, int customerId);
}
