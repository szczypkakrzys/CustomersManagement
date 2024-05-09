using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.TravelAgency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Tours;

[Authorize(Policy = Policies.TravelAgency)]
public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ITourService Tour { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    public string Message { get; set; } = string.Empty;
    public string ValidationErrors { get; set; }

    public TourDetailsVM Model { get; set; } = new TourDetailsVM
    {
        Status = "Oczekuje na rozpocz�cie"
    };

    async Task CreateTour()
    {
        var response = await Tour.CreateTour(Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/travelagency/tours/");
            _message.Success("Poprawnie dodano now� wycieczk�");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda�o si� doda� nowej wycieczki");
        }
    }
}