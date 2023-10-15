using FluentValidation;

namespace TaskManagement.DTOs.Status.Validator
{
    public class CreateStatusValidator : AbstractValidator<StatusDto>
    {
        public CreateStatusValidator()
        {
            RuleFor(s => s.Title)
                .MaximumLength(15)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Title not Valid");
        }
    }
}
