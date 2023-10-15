using FluentValidation;

namespace TaskManagement.DTOs.Subject.Validator
{
    public class CreateSubjectValidator : AbstractValidator<SubjectDto>
    {
        public CreateSubjectValidator()
        {
            RuleFor(s => s.Title)
                .MaximumLength(15)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Title not Valid");
        }
    }
}
