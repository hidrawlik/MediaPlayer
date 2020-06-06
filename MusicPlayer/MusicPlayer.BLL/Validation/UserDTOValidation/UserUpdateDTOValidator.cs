using FluentValidation;
using MusicPlayer.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.Validation
{
    public class UserUpdateDTOValidator : AbstractValidator<UserUpdateDTO>
    {
        public UserUpdateDTOValidator()
        {
            RuleFor(e => e.UserName)
                .NotEmpty()
                .MinimumLength(2)
                .MaximumLength(20);

            RuleFor(e => e.Email)
                .NotEmpty()
                .EmailAddress();

            RuleFor(e => e.NewPassword)
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword)
                .NotNull()
                .Equal(e => e.NewPassword);

            RuleFor(e => e.FirstName)
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(e => e.LastName)
                .MinimumLength(2)
                .MaximumLength(30);

            RuleFor(e => e.DateOfBirth.Year)
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1900);

            RuleFor(e => e.DateOfBirth.Month)
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(12);

            RuleFor(e => e.DateOfBirth.Day)
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .LessThanOrEqualTo(31);
        }
    }
}
