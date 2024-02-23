using CustomersManagement.Application.Contracts.Persistence;
using CustomersManagement.Domain;
using CustomersManagement.Persistence.DatabaseContext;

namespace CustomersManagement.Persistence.Repositories;

public class FormFillRulesSetRepository : GenericRepository<FormFillRulesSet>, IFormFillRulesSetRepository
{
    public FormFillRulesSetRepository(ClientsDatabaseContext context) : base(context)
    {
    }
}
