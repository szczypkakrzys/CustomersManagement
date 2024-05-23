using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Newsletter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Newsletter.DivingSchool;

[Authorize(Policy = Policies.DivingSchool)]
public partial class Templates
{
    [Inject]
    public IEmailService EmailService { get; set; }
    //TODO
    //ogarnaæ wybieranie i usuwanie
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
        EmailTemplates = await EmailService.GetTemplates(Services.Base.EmailType._1);
    }
}