using languageInstitute.Models;

namespace languageInstitute.Contract;

public interface IStudentBusiness
{
    List<Student> GetStudents();
    Student GetStudentByNationalCode(string NationalCode);
    bool AddStudent(Student student);
}
