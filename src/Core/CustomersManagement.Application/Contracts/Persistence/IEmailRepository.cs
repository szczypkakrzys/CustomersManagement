using CustomersManagement.Domain.Email;

namespace CustomersManagement.Application.Contracts.Persistence;

public interface IEmailRepository : IGenericRepository<EmailTemplate>
{
    Task<IEnumerable<EmailTemplate>> GetByType(EmailType type);
}
