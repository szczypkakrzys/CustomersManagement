using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.DivingSchool;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Courses;

public partial class Create
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ICourseService Course { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    public string Message { get; set; } = string.Empty;
    public string ValidationErrors { get; set; }

    public CourseDetailsVM Model { get; set; } = new CourseDetailsVM
    {
        Status = "Oczekuje na rozpocz�cie"
    };

    async Task CreateCourse()
    {
        var response = await Course.CreateCourse(Model);
        if (response.IsSuccess)
        {
            NavManager.NavigateTo("/divingschool/courses/");
            _message.Success("Poprawnie dodano nowy kurs");
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda�o si� doda� nowego kursu");
        }
    }
}