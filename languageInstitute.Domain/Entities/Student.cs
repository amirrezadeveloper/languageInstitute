
using languageInstitute.Domain.Contracts;

namespace languageInstitute.Domain.Entities;

public class Student: BaseEntity<int>
{
    
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public string FathersJob { get; set; }
    public string EducationLevel { get; set; }

}
