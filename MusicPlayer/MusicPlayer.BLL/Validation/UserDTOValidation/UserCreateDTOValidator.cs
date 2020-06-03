using FluentValidation;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.DTOs.UserDTO;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.BLL.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.Validation
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
                .NotEmpty()
                .MinimumLength(6);

            RuleFor(e => e.ConfirmPassword)
                .NotNull()
                .Equal(e => e.Password);
        }
    }
}
