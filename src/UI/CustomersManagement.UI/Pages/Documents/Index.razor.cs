using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Customers;
using CustomersManagement.UI.Models.Documents;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace CustomersManagement.UI.Pages.Documents;

public partial class Index
{
    [Inject]
    public NavigationManager _navManager { get; set; }

    [Inject]
    public IDocumentService _documentsClient { get; set; }

    [Inject]
    public IJSRuntime _js { get; set; }

    public List<DocumentVM> documents { get; private set; }
    public string Message { get; set; } = string.Empty;

    private bool showCustomers = false;

    [Inject]
    public ICustomerService _customersClient { get; set; }

    public List<CustomerVM> customers = new List<CustomerVM>();
    protected override async Task OnInitializedAsync()
    {
        await LoadDocuments();
    }

    protected async Task LoadDocuments()
    {
        documents = await _documentsClient.GetAllDocuments();
    }

    protected async Task LoadCustomers()
    {
        showCustomers = !showCustomers;

        if (showCustomers)
            customers = await _customersClient.GetAllCustomers();
    }

    protected async Task Download(int id, string fileName)
    {
        //var response = await _client.CreateCustomer(customer);
        //if (!response.IsSuccess)
        //{
        //    Message = response.Message;
        //}
        //throw new NotImplementedException();

        var response = await _documentsClient.DownloadDocument(id, fileName);

    }

    protected async Task GenerateDocumentForCustomer(string fileName, int customerId)
    {
        //this will show a list of all users on click and will allow to click on option - "wystaw dokument" and then our document will be downloaded
        //so this will show just another view inside view - button will change boolean property so it will know when to open 
        //and according to which document has been choose the document name or something will go to API
        //will shoot to API with method - generate document for customer with id = customerid, and fileName or something else to differentiate customers

        var response = await _documentsClient.GenerateDocument(fileName, customerId);
        if (response.IsSuccess)
        {
            _navManager.NavigateTo("/customers/");
        }
        Message = response.Message;
    }

    protected void UploadDocument()
    {
        _navManager.NavigateTo("/documents/upload");
    }
}