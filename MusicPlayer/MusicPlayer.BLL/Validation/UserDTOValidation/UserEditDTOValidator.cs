using FluentValidation;
using MediaPlayer.BLL.DTOs.UserDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.Validation
{
    public class UserEditDTOValidator : AbstractValidator<UserEditDTO>
    {
        public UserEditDTOValidator()
        {
            RuleFor(e => e.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword)
                .NotNull()
                .Equal(e => e.Password);

            RuleFor(e => e.FirstName)
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(e => e.LastName)
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(e => e.DateOfBirth.Year)
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1900);

            RuleFor(e => e.DateOfBirth.Month)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(12);

            RuleFor(e => e.DateOfBirth.Day)
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(31);
        }
    }
}
