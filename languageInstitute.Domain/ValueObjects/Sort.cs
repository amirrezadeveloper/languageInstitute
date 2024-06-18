using System.ComponentModel.DataAnnotations.Schema;

namespace languageInstitute.Domain.ValueObjects;

[NotMapped]
public class Sort
{
    public string PropertyName { get; set; }
    public bool IsAscending { get; set; }
}
