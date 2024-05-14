using CustomersManagement.UI.Models.Emloyee;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Routing;

namespace CustomersManagement.UI.Pages.SystemUsers;

public partial class Index
{
    [Inject]
    public NavigationManager NavManager { get; set; }
    public List<EmployeeVM> Employees { get; set; }
    public string Message { get; set; } = string.Empty;

    protected override void OnInitialized()
    {
        NavManager.LocationChanged += HandleLocationChanged;
        UpdateRole(NavManager.Uri);
    }

    private void HandleLocationChanged(object sender, LocationChangedEventArgs args)
    {
        UpdateRole(args.Location);
    }
    string role;
    private void UpdateRole(string uri)
    {
        var query = new Uri(uri).Query;
        role = query.Split('=')[1];

        if (role.Contains("Administrator"))
        {
            // Handle role "{Administrator}"
        }
        else if (role.Contains("TravelAgency"))
        {
            // Handle role "{Travel Agency Employee}"
        }
        else if (role.Contains("DivingSchool"))
        {
            // Handle role "{Diving School Employee}"
        }
    }
}