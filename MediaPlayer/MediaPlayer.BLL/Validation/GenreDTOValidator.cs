using FluentValidation;
using MediaPlayer.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.Validation
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
