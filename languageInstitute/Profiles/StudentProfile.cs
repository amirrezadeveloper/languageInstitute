using AutoMapper;
using languageInstitute.Dtos;
using languageInstitute.Models;

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
