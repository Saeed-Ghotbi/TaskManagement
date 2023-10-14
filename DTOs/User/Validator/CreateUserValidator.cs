using FluentValidation;

namespace TaskManagement.DTOs.User.Validator
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(u => u.PhoneNumber)
                .Length(11)
                .WithMessage("phoneNumber not Valid");

            RuleFor(u => u.Email)
                .EmailAddress()
                .WithMessage("email not Valid");

            RuleFor(u => u.Password)
                .MaximumLength(15)
                .MinimumLength(5)
                .WithMessage("password not Valid");
        }
    }
}
