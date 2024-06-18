using languageInstitute.Domain.Contracts;

namespace languageInstitute.Domain.Entities;

public class Courses: BaseEntity<int>
{
    public string Title { get; set; }

    public int BookId { get; set; } 
    public int AgeGroupId {  get; set; }    
}
 