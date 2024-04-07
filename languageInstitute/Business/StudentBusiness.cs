using languageInstitute.Context;
using languageInstitute.Contract;
using languageInstitute.Models;

namespace languageInstitute.Business;

public class StudentBusiness : IStudentBusiness
{
    private readonly ApplicationDbContext _context;
    public StudentBusiness(ApplicationDbContext context) => _context = context;
    

    //static public List<Student> Students = new List<Student>()
    //{
    //    new Student() { Id = 1, Name = "Amir", BirthDate = "1376/07/03", NationalCode = "0020429355", PhoneNumber = "09102305286" },
    //    new Student() { Id = 2, Name = "Reza", BirthDate = "1376/07/03", NationalCode = "0151614285", PhoneNumber = "09356671110" },
    //};
    public bool AddStudent(Student student)
    {
        _context.Students.Add(student);
        _context.SaveChanges();
        return true;
    }

    public Student GetStudentByNationalCode(string NationalCode)
    {
        // var student = Students.Where(x => x.NationalCode == NationalCode).FirstOrDefault();
        var student = _context.Students.Where(x => x.NationalCode == NationalCode).FirstOrDefault();
        return student;
    }

    public List<Student> GetStudents()
    {
        return _context.Students.ToList();
    }
}
