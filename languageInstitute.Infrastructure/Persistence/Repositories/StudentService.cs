using languageInstitute.Application.Contracts;
using languageInstitute.Application.Dtos;
using languageInstitute.Application.Wrappers;
using languageInstitute.Domain.Entities;
using languageInstitute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace languageInstitute.Infrastructure.Persistence.Repositories;

public class StudentService : IStudentService
{
    private readonly ApplicationDbContext _context;
    public StudentService(ApplicationDbContext context) => _context = context;



    public async Task<Response<Domain.Entities.Student>> GetStudentById(int id)
    {
       var student = await _context.Students.SingleOrDefaultAsync(s => s.Id == id); 
        return new Response<Domain.Entities.Student>(student);   
    }

    public async Task<Response<List<Student>>> GetStudents()
    {   
        var students = await _context.Students.AsNoTracking().ToListAsync(); 
        return new Response<List<Student>>(students);
    }

    public async Task<Response<bool>> AddStudent(Student student)
    {

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }

    public interface IStudentBusiness
    {
        Task<bool> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
    }

    public async Task<Response<bool>> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto)
    {
        var existingStudent = await _context.Students.FindAsync(id);
        if (existingStudent == null)
            return new Response<bool>(false);

        existingStudent.FullName = updatedStudentDto.FullName;
        existingStudent.BirthDate = updatedStudentDto.BirthDate;
        existingStudent.PhoneNumber = updatedStudentDto.PhoneNumber;
        existingStudent.NationalCode = updatedStudentDto.NationalCode;
        existingStudent.Address = updatedStudentDto.Address;
        existingStudent.FathersJob = updatedStudentDto.FathersJob;
        existingStudent.EducationLevel = updatedStudentDto.EducationLevel;

        await _context.SaveChangesAsync();
        return new Response<bool>(true);
    }
}
