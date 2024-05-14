using CustomersManagement.UI.Models.Newsletter;
using CustomersManagement.UI.Services.Base;

namespace CustomersManagement.UI.Contracts;

public interface IEmailService
{
    Task<Response<Guid>> SendEmail(EmailVM email);
}
