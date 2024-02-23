using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Services.Base;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace CustomersManagement.UI.Pages.Documents;

public partial class Upload
{
    [Inject]
    public IDocumentService _client { get; set; }
    private readonly int maxAllowedFiles = int.MaxValue;
    private readonly long maxFileSize = long.MaxValue;
    private List<string> fileNames = new(); //what's the difference between new() and list.empty???

    //todo
    //get deeper understand of following code
    private async Task OnInputFileChange(InputFileChangeEventArgs e)
    {
        var files = new List<FileParameter>();

        foreach (var file in e.GetMultipleFiles(maxAllowedFiles))
        {
            var fileContent = new StreamContent(file.OpenReadStream(maxFileSize));
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            var fileParameter = new FileParameter(
                data: await fileContent.ReadAsStreamAsync(),
                fileName: file.Name,
                contentType: file.ContentType);

            files.Add(fileParameter);
        }

        var response = await _client.UploadDocument(files, DocumentType._0);
    }
}