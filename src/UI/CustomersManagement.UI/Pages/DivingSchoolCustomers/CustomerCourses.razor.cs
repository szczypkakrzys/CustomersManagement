using AntDesign;
using CustomersManagement.UI.Contracts;
using CustomersManagement.UI.Models.DivingSchool;
using CustomersManagement.UI.Models.Shared;
using Microsoft.AspNetCore.Components;

namespace CustomersManagement.UI.Pages.DivingSchoolCustomers;
public partial class CustomerCourses
{
    [Inject]
    public NavigationManager NavManager { get; set; }

    [Inject]
    IDivingSchoolCustomerService CustomerService { get; set; }

    [Inject]
    IMessageService _message { get; set; }

    [Parameter]
    public int Id { get; set; }

    DivingSchoolCustomerDetailsVM customer = new();
    public List<CustomerActivityVM> customerCourses { get; private set; }
    CustomerActivityDetailsVM? customerCourseDetails { get; set; }
    public string Message { get; set; } = string.Empty;
    public string SearchText = "";
    public bool CoursesListCollapsed = true;
    string AddToCourseActionText { get => CoursesListCollapsed ? "Dodaj do kursu" : "Zwi� list�"; }


    bool customerCourseDetailsModalVisible = false;
    int modalCourseId;
    string modalCourseName = "";

    private string CustomerCourseDetailsModalName() =>
        "Szczeg�y kursu " + modalCourseName;

    double newPaymentValue;
    bool paymentModalVisible = false;

    List<CustomerActivityVM> FilteredCourses => customerCourses.Where(
           course => (course.Name + course.TimeStart + course.TimeEnd).Contains(SearchText, StringComparison.CurrentCultureIgnoreCase)).ToList();

    protected override async Task OnParametersSetAsync()
    {
        customer = await CustomerService.GetCustomerDetails(Id);
        customerCourses = await CustomerService.GetCustomerCourses(Id);
    }

    protected async void ShowCustomerCourseDetails(int customerId, int courseId)
    {
        customerCourseDetails = await CustomerService.CustomerCourseDetails(customerId, courseId);
    }

    protected async Task RemoveFromCourse(int customerId, int courseId)
    {
        var response = await CustomerService.RemoveCustomerFromCourse(customerId, courseId);
        if (response.IsSuccess)
        {
            customerCourses = await CustomerService.GetCustomerCourses(Id);
            _message.Info("Usuni�to klienta z kursu");
        }
        else
        {
            _message.Error("Nie uda�o si� usun�� klienta z kursu");
            Message = response.Message;
        }
    }
    [Inject]
    public ICourseService Course { get; set; }
    public List<ActivityVM> Courses { get; private set; }
    public string AllCoursesSearchText = "";
    List<ActivityVM> FilteredAllCoursesList => Courses.Where(
            course => (course.Name + course.TimeStart + course.TimeEnd).Contains(AllCoursesSearchText, StringComparison.CurrentCultureIgnoreCase)).ToList();
    bool confirmModalVisible = false;
    string choosenCourseName = "";
    int assignCourseId;
    protected async Task ToggleCoursesList()
    {
        CoursesListCollapsed = !CoursesListCollapsed;
        Courses = await Course.GetAllCourses();
    }
    private async Task AssignCustomerToCourseHandler(int courseId, int customerId)
    {
        var response = await CustomerService.AssignCustomerToCourse(customerId, courseId);
        if (response.IsSuccess)
        {
            _message.Success("Przypisano klienta do kursu");
            customerCourses = await CustomerService.GetCustomerCourses(Id);
        }
        else
        {
            Message = response.Message;
            _message.Error("Nie uda�o si� przypisa� klienta do kursu");
        }
    }
    protected void CourseDetails(int id)
    {
        NavManager.NavigateTo($"/divingschool/courses/details/{id}");
    }
    protected void ShowCustomerCourseDetailsModal(int customerId, int courseId)
    {
        ShowCustomerCourseDetails(customerId, courseId);
        customerCourseDetailsModalVisible = true;
    }

    protected void ShowPaymentModal()
    {
        paymentModalVisible = true;
    }

    protected async Task AddPayment(int customerId, int courseId, double paymentAmount)
    {
        var response = await CustomerService.UpdateCustomerPayment(
            customerId,
            courseId,
            paymentAmount);

        if (response.IsSuccess)
        {
            newPaymentValue = 0;
            customerCourseDetails = await CustomerService.CustomerCourseDetails(customerId, courseId);
            _message.Success("Dodano now� p�atno��");
        }
    }

    protected void ClearCustomerCourseDetails()
    {
        customerCourseDetails = null;
    }
}
