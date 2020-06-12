using FluentValidation;
using MusicPlayer.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.Validation
{
    public class UserLoginDTOValidator : AbstractValidator<UserLoginDTO>
    {
        public UserLoginDTOValidator()
        {
            RuleFor(e => e.Email)
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.Password)
                .NotNull();
        }
    }
}
