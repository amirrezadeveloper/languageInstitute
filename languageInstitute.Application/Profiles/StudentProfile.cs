using AutoMapper;
using languageInstitute.Domain.Entities;
using languageInstitute.Application.Dtos;

namespace languageInstitute.Application.Profiles;

public class StudentProfile: Profile
{
    public StudentProfile()
    {
        CreateMap<AddStudentDto, Student>();
        CreateMap<UpdatedStudentDto, Student>();
        CreateMap<TeacherDto, Courses>();
    }
}
