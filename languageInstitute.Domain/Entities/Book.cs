
using languageInstitute.Domain.Contracts;

namespace languageInstitute.Domain.Entities;

public class Book: BaseEntity<int>
{
    public string Title { get; set; }
    public string Description { get; set; }

    public int AgeGroupId {  get; set; }    

}
