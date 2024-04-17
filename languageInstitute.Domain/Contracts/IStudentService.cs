using languageInstitute.Domain.Entities;


namespace languageInstitute.Domain.Contracts;

public interface IStudentService
{
    Task<Student> GetStudentById(int id);
    Task<List<Student>> GetStudents();
    Task<bool> AddStudent(Student student);
    Task<bool> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
}
