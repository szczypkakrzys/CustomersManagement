using AntDesign;
using Blazored.TextEditor;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.Newsletter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Newsletter.TravelAgency;

[Authorize(Policy = Policies.TravelAgency)]
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

    //TODO
    //configure this to have property on body, to allow create this component with predefined contents

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
        email.ReceiversAddresses = ReceiversAddresses;
        email.Subject = Subject;

        var response = await EmailService.SendEmail(email);

        if (response.IsSuccess)
        {
            MessageSuccessModalVisible = true;
            //TODO
            //navigate to newsletter main page
        }
        else
        {
            _message.Error("Nie uda³o siê wys³aæ wiadomoœci");
        }
    }
}