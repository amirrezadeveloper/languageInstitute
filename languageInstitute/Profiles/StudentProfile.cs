using AutoMapper;
using languageInstitute.Domain.Entities;
using languageInstitute.Dtos;

namespace languageInstitute.Profiles;

public class StudentProfile: Profile
{
    public StudentProfile()
    {
        CreateMap<AddStudentDto, Student>();
        CreateMap<UpdatedStudentDto, Student>();
        CreateMap<TeacherDto, Teacher>();
    }
}
