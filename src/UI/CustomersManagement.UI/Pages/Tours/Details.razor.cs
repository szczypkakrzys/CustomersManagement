using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Tours;

public partial class Details
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    ITourService Tour { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    [Parameter]
    public int Id { get; set; }

    TourDetailsVM tour = new();
    public string Message { get; set; } = string.Empty;

    protected override async Task OnParametersSetAsync()
    {
        tour = await Tour.GetTourDetails(Id);
    }
    protected void EditTour(int id)
    {
        NavManager.NavigateTo($"/travelagency/tours/edit/{id}");
    }

    protected async void DeleteTour(int id)
    {
        var response = await Tour.DeleteTour(id);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/travelagency/tours/");
            _message.Info("Poprawnie usuni�to wycieczk�");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda�o si� usun�� wycieczki");
        }
    }
}