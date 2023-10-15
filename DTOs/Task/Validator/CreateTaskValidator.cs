using FluentValidation;

namespace TaskManagement.DTOs.Task.Validator
{
    public class CreateTaskValidator : AbstractValidator<CreateTaskDto>
    {
        public CreateTaskValidator()
        {
            RuleFor(t => t.Title)
                .MaximumLength(15)
                .NotEmpty()
                .MinimumLength(5)
                .WithMessage("Title not Valid");

            RuleFor(t => t.Description)
                .MaximumLength(1000)
                .MinimumLength(10)
                .WithMessage("Description not Valid");

            RuleFor(t => t.StatusId)
                .NotNull()
               .GreaterThan(0);

            RuleFor(t => t.AssignmentId)
                .NotNull()
                .GreaterThan(0);

            RuleFor(t => t.SubjectId)
                .NotNull()
                .GreaterThan(0);
        }
    }
}
