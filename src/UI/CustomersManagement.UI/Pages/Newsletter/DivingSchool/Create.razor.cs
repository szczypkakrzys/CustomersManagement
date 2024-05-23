using AntDesign;
using Blazored.TextEditor;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Newsletter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Newsletter.DivingSchool;

[Authorize(Policy = Policies.DivingSchool)]
public partial class Create
{

    [Inject]
    public NavigationManager _navManager { get; set; }

    [Inject]
    public IEmailService EmailService { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    public string Message { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;

    EmailVM email = new();

    public List<string> ReceiversAddresses { get; set; } = new List<string>();

    BlazoredTextEditor QuillHtml;

    string HtmlContent = string.Empty;

    List<string> options = new();

    public string inputValue { get; set; }

    bool MessageSuccessModalVisible = false;

    private MarkupString htmlContent;
    private bool previewModalVisible = false;

    private async Task OpenPreviewModal()
    {
        string htmlString = await QuillHtml.GetHTML();
        htmlContent = (MarkupString)htmlString;
        previewModalVisible = true;
    }

    private void UpdateEmailList(ChangeEventArgs e)
    {
        string input = e.Value?.ToString();
        if (input.EndsWith(" ") && !string.IsNullOrWhiteSpace(input))
        {
            input = input.Remove(input.Length - 1, 1) + "; ";
            inputValue = input;
        }

        string[] emails = input.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

        ReceiversAddresses.Clear();

        foreach (var email in emails)
        {
            if (string.IsNullOrWhiteSpace(email)) continue;

            ReceiversAddresses.Add(email.Trim());
        }
    }

    private void CloseEmailList()
    {
        if (!inputValue.EndsWith(";") && !inputValue.EndsWith(" "))
            inputValue += "; ";
    }

    private async Task SendMessage()
    {
        email.EmailContent = await QuillHtml.GetHTML();
        await Console.Out.WriteLineAsync(email.EmailContent);
        email.ReceiversAddresses = ReceiversAddresses;
        email.Subject = Subject;

        var response = await EmailService.SendEmail(email);

        if (response.IsSuccess)
        {
            MessageSuccessModalVisible = true;
        }
        else
        {
            _message.Error("Nie uda³o siê wys³aæ wiadomoœci");
        }
    }

    private void OpenTemplates()
    {
        _navManager.NavigateTo("/divingschool/newsletter/templates");
    }
}