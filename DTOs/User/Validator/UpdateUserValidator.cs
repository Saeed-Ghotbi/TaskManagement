using FluentValidation;

namespace TaskManagement.DTOs.User.Validator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            RuleFor(u => u.PhoneNumber)
                .Length(11)
                .WithMessage("phoneNumber not Valid");

            RuleFor(u => u.Password)
                .MaximumLength(15)
                .MinimumLength(5)
                .WithMessage("password not Valid");
        }
    }
}
