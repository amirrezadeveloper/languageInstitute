using languageInstitute.Domain.Contracts;
using languageInstitute.Domain.Entities;
using languageInstitute.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;



namespace languageInstitute.Infrastructure.Persistence.Repositories;

public class StudentService: IStudentService
{
    private readonly ApplicationDbContext _context;
    public StudentService(ApplicationDbContext context) => _context = context;



    public async Task<Domain.Entities.Student> GetStudentById(int id)
    {
        return await _context.Students.FindAsync(id);
    }

    public async Task<List<Student>> GetStudents()
    {
        var students = await _context.Students.AsNoTracking().ToListAsync();
        return students;
    }

    public async Task<bool> AddStudent(Student student)
    {

        await _context.Students.AddAsync(student);
        await _context.SaveChangesAsync();
        return true;
    }

    public interface IStudentBusiness
    {
        Task<bool> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto);
    }

    public async Task<bool> UpdateStudent(int id, UpdatedStudentDto updatedStudentDto)
    {
        var existingStudent = await _context.Students.FindAsync(id);
        if (existingStudent == null)
            return false;

        existingStudent.FullName = updatedStudentDto.FullName;
        existingStudent.BirthDate = updatedStudentDto.BirthDate;
        existingStudent.PhoneNumber = updatedStudentDto.PhoneNumber;
        existingStudent.NationalCode = updatedStudentDto.NationalCode;
        existingStudent.Address = updatedStudentDto.Address;
        existingStudent.FathersJob = updatedStudentDto.FathersJob;
        existingStudent.EducationLevel = updatedStudentDto.EducationLevel;

        await _context.SaveChangesAsync();
        return true;
    }
