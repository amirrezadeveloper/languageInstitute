using FluentValidation;

namespace languageInstitute.Application.Dtos;

public class UpdatedStudentDto
{
    public string FullName { get; set; }
    public string BirthDate { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalCode { get; set; }
    public string Address { get; set; }
    public string FathersJob { get; set; }
    public string EducationLevel { get; set; }
}

public class UpdateStudentDtoValidator : AbstractValidator<UpdatedStudentDto>
{
    public UpdateStudentDtoValidator()
    {
        RuleFor(x => x.FullName)
            .NotNull()
            .NotEmpty()
            .NotEqual("")
            .MinimumLength(2)
            .MaximumLength(250)
            .WithMessage("Enter a valid name");

        RuleFor(x => x.BirthDate)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .MaximumLength(10)
            .WithMessage("Enter a valid birthdate");

        
    }
}
