using Blazored.TextEditor;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Newsletter;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Newsletter
{
    public partial class Index
    {
        [Inject]
        public NavigationManager _navManager { get; set; }

        [Inject]
        public IEmailService _client { get; set; }

        public string Message { get; set; } = string.Empty;

        EmailVM email = new();

        BlazoredTextEditor QuillHtml;
        string HtmlContent = string.Empty;

        public async Task sendMessage()
        {
            HtmlContent = await this.QuillHtml.GetHTML();
            email.MessageContent = HtmlContent;
            //StateHasChanged();

            var response = await _client.SendEmail(email);
            if (response.IsSuccess)
            {

            }
            Message = response.Message;
        }

        public async void GetHTML()
        {
            HtmlContent = await this.QuillHtml.GetHTML();
            StateHasChanged();
        }

        public async void SetHTML()
        {
            string QuillContent =
                @"<a href='http://BlazorHelpWebsite.com/'>" +
                "<img src='images/BlazorHelpWebsite.gif' /></a>";

            await this.QuillHtml.LoadHTMLContent(QuillContent);
            StateHasChanged();
        }
    }
}