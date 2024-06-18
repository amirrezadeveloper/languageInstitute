using languageInstitute.Domain.Contracts;
using languageInstitute.Infrastructure.Identity.Entities;

namespace languageInstitute.Domain.Entities;

public class Class : BaseEntity<int>
{
    public string ClassName {  get; set; }  
    public int CourseId {  get; set; }  
    public int GenderId { get; set; }
    public int TeacherId {  get; set; } 
    public ICollection<Users> students { get; set; }

}
