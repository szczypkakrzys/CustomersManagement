using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain;

public class FormFillRulesSet : BaseEntity
{
    public int DocumentId { get; set; }
    public Document Document { get; set; }
    //todo:
    //consider adding property: userMacros -> where user custom names for textboxes will be stored 
    public string TextBoxesWithValues { get; set; } //todo -> map to JSON and then deserialize to Dictionary<string, string>
    public ICollection<string> PropertiesRequiredToFillDocument { get; set; }
}
