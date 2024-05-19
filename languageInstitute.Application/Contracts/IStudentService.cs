using languageInstitute.Application.Dtos;
using languageInstitute.Application.Wrappers;
using languageInstitute.Domain.Entities;


namespace languageInstitute.Application.Contracts;

public interface IStudentService
{
    Task<Response<Student>> GetStudentById(int id);
    Task<Response<List<Student>>> GetStudents();
    Task<Response<bool>> AddStudent(Student student);
    Task<Response<bool>> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
}
