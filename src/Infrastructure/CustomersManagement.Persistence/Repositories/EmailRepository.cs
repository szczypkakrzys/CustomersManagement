using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain.Email;
using CustomersManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace CustomersManagement.Persistence.Repositories;

public class EmailRepository : GenericRepository<EmailTemplate>, IEmailRepository
{
    public EmailRepository(CustomerDatabaseContext context) : base(context)
    {
    }

    public async Task<IEnumerable<EmailTemplate>> GetByType(EmailType type)
    {
        return await _context.EmailTemplates
        .Where(template => template.Type == type
                           || template.Type == EmailType.Shared)
        .ToListAsync();
    }
}
