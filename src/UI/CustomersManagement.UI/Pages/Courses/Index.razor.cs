using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.Shared;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.Courses;

public partial class Index
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    public ICourseService Course { get; set; }

    public List<ActivityVM> Courses { get; private set; }
    public string Message { get; set; } = string.Empty;
    public string SearchText = "";
    List<ActivityVM> FilteredCourses => Courses.Where(
            course => (course.Name + course.TimeStart + course.TimeEnd).Contains(SearchText, StringComparison.CurrentCultureIgnoreCase)).ToList();
    protected override async Task OnInitializedAsync()
    {
        await LoadCourses();
    }

    protected void CreateCourse()
    {
        NavManager.NavigateTo("/divingschool/courses/create/");
    }

    protected void CourseDetails(int id)
    {
        NavManager.NavigateTo($"/divingschool/courses/details/{id}");
    }

    public bool ParticipantsListCollapsed = true;

    Dictionary<int, bool> ParticipantsListCollapsedStates = [];

    protected async Task LoadCourses()
    {
        Courses = await Course.GetAllCourses();

        foreach (var course in Courses)
        {
            ParticipantsListCollapsedStates[course.Id] = true;
        }
    }

    protected void ToggleParticipantsList(int courseId)
    {
        ParticipantsListCollapsedStates[courseId] = !ParticipantsListCollapsedStates[courseId];
    }

    string GetParticipantsActionText(int tourId)
    {
        return ParticipantsListCollapsedStates[tourId] ? "Poka¿ uczestników" : "Zwiñ listê";
    }
}