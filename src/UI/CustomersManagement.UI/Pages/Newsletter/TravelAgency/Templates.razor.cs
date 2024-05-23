using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Newsletter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Newsletter.TravelAgency;

[Authorize(Policy = Policies.TravelAgency)]
public partial class Templates : ComponentBase
{
    [Inject]
    public IEmailService EmailService { get; set; }

    public List<EmailTemplateVM> EmailTemplates { get; private set; }

    private bool previewModalVisible = false;
    private MarkupString previewContent;
    private string previewTitle;

    private MarkupString ShowTemplate(string content)
    {
        return (MarkupString)content;
    }

    private async Task OpenPreviewModal(EmailTemplateVM template)
    {
        previewContent = (MarkupString)template.Content;
        previewTitle = template.Name;

        previewModalVisible = true;
    }

    protected override async Task OnInitializedAsync()
    {
        await LoadTemplates();
    }

    private async Task LoadTemplates()
    {
        EmailTemplates = await EmailService.GetTemplates(Services.Base.EmailType._0);
    }
}

