namespace CustomersManagement.UI.Models.Documents;

public class DocumentVM
{
    public int Id { get; set; }
    public string FileName { get; set; } = string.Empty;
    //todo:
    //create custom mapper to below properties

    //public string CustomName { get; set; } = null!;
    //public string FileExtenstion { get; set; } = string.Empty;
    //should contain filed with datetime when was modified or created :D
}
