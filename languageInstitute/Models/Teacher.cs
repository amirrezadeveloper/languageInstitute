using languageInstitute.Contract;

namespace languageInstitute.Models;

public class Teacher: BaseEntity<int>
{
    public string Name { get; set; }
    public string BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalCode { get; set; }

}
