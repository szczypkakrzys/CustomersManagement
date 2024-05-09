using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models;
using CustomersManagement.UI.Models.DivingSchool;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Courses;

[Authorize(Policy = Policies.DivingSchool)]
public partial class Edit
{
    [Inject]
    ICourseService Course { get; set; }

    [Inject]
    NavigationManager NavManager { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    [Parameter]
    public int Id { get; set; }
    public string Message { get; private set; }

    CourseDetailsVM Model = new();

    protected override async Task OnParametersSetAsync()
    {
        Model = await Course.GetCourseDetails(Id);
    }

    private async Task UpdateCourse()
    {
        var response = await Course.UpdateCourse(Id, Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/divingschool/courses/");
            _message.Success("Poprawnie zaaktualizowano dane kursu");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda³o siê edytowaæ danych kursu");
        }
    }
}