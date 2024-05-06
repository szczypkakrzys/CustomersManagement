using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.DivingSchool;

public class DivingSchoolCustomer : Customer
{
    public string DivingCertificationLevel { get; set; }
    public ICollection<DivingCourse> DivingCourses { get; set; }
    public ICollection<CustomersDivingCoursesRelations> DivingCoursesRelations { get; set; }

}
