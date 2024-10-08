﻿using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain.DivingSchool;

public class CustomersDivingCoursesRelations : CustomersActivitiesRelations
{
    public int CustomerId { get; set; }
    public DivingSchoolCustomer Customer { get; set; }
    public int DivingCourseId { get; set; }
    public DivingCourse DivingCourse { get; set; }
}
