namespace CustomersManagement.Application.Models.Identity;

public static class RoleName
{
    public const string Administrator = "Administrator";
    public const string TravelAgencyEmployee = "Travel Agency Employee";
    public const string DivingSchoolEmployee = "Diving School Employee";

    public static string GetRoleName(Role role)
    {
        switch (role)
        {
            case Role.Administrator:
                return Administrator;
            case Role.TravelAgencyEmployee:
                return TravelAgencyEmployee;
            case Role.DivingSchoolEmployee:
                return DivingSchoolEmployee;
        }
        return string.Empty;
    }
}
