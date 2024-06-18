using languageInstitute.Application.Dtos;
using languageInstitute.Application.Wrappers;
using languageInstitute.Domain.Contracts;
using languageInstitute.Domain.Entities;


namespace languageInstitute.Application.Contracts;

public interface IClasstService: IGenericRepository<Class> 
{
    //Task<Response<Class>> GetStudentById(int id);
    //Task<Response<List<Class>>> GetStudents();
    //Task<Response<bool>> AddStudent(Class student);
    //Task<Response<bool>> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
}
