using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.DivingSchool;

public class DivingCourse : CustomerActivity
{
    public ICollection<DivingSchoolCustomer> Participants { get; set; }
    public ICollection<CustomersDivingCoursesRelations> DivingCourseRelations { get; set; }
}
