
using FluentValidation;

namespace languageInstitute.Dtos
{
    public class AddStudentDto
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalCode { get; set; }
        public string Address { get; set; }
        public string FathersJob { get; set; }
        public string EducationLevel { get; set; }
    }

    public class AddStudentDtoValidator : AbstractValidator<AddStudentDto>
    {
        public AddStudentDtoValidator()
        {
           RuleFor(x => x.FullName)
            .NotNull()
            .NotEmpty()
            .MinimumLength(2)
            .WithMessage("Please enter valid name");
        }
        
    }
}
