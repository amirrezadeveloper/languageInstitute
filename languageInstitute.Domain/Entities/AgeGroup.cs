using languageInstitute.Domain.Contracts;
namespace languageInstitute.Domain.Entities;

public class AgeGroup : BaseEntity<int>
{

    public string Caption { get; set; }
    public string AgeRange { get; set; }

    public ICollection<Book> Books { get; set; }
}
