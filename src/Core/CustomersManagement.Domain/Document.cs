using CustomersManagement.Domain.Common;

namespace CustomersManagement.Domain;

public class Document : BaseEntity
//todo
//consider adding table - FormFillsRules, where all rules will be stored
{
    public string Type { get; set; } = string.Empty; //todo Type = enum type later on 
    public string RemotePath { get; set; } = string.Empty;
    public string FileName { get; set; } = string.Empty; //todo: probabaly won't be possible when adding multiple files
    public string ContentType { get; set; } = string.Empty;
    public int? FormFillRulesSetId { get; set; }
    public FormFillRulesSet? FormFillRulesSet { get; set; }
    public int? ClientId { get; set; }
    public Client? Client { get; set; }
}
