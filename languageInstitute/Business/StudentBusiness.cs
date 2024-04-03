using languageInstitute.Contract;
using languageInstitute.Models;

namespace languageInstitute.Business;

public class StudentBusiness : IStudentBusiness
{
    static public List<Student> Students = new List<Student>()
    {
        new Student() { Id = 1, Name = "Amir", BirthDate = "1376/07/03", NationalCode = "0020429355", PhoneNumber = "09102305286" },
        new Student() { Id = 2, Name = "Reza", BirthDate = "1376/07/03", NationalCode = "0151614285", PhoneNumber = "09356671110" },
    };
    public bool AddStudent(Student student)
    {
        Students.Add(student);
        return true;
    }

    public Student GetStudentByNationalCode(string NationalCode)
    {
        var student = Students.Where(x => x.NationalCode == NationalCode).FirstOrDefault();
        return student;
    }

    public List<Student> GetStudents()
    {
        return Students;
    }
}
