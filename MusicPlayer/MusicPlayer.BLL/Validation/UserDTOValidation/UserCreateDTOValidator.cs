using FluentValidation;
using MusicPlayer.BLL.DTOs;

namespace MusicPlayer.BLL.Validation
{
    public class UserCreateDTOValidator : AbstractValidator<UserCreateDTO>
    {
        public UserCreateDTOValidator()
        {
            RuleFor(e => e.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotEmpty();

            RuleFor(e => e.ConfirmPassword)
                .Equal(e => e.Password);
        }
    }
}
