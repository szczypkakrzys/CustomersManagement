using CustomersManagement.UI.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace CustomersManagement.UI.Models.DivingSchool;

public class DivingSchoolCustomerDetailsVM : CustomerVM
{
    public int Id { get; set; }
    [Required(ErrorMessage = "Stopień nurkowy jest wymagany")]
    public string DivingCertificationLevel { get; set; } = string.Empty;
    public AddressVM Address { get; set; }
}
