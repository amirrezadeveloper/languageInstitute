using languageInstitute.Dtos;
using languageInstitute.Models;

namespace languageInstitute.Contract;

public interface IStudentBusiness
{
    Task<Student> GetStudentById(int id);
    Task<List<Student>> GetStudents();
    Task<bool> AddStudent(Student student);
    Task<bool> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
}
