using FluentValidation;
using MusicPlayer.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.Validation
{
    public class GenreDTOValidator : AbstractValidator<GenreDTO>
    {
        public GenreDTOValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(30);
        }
    }
}
