﻿using System;
using FluentValidation;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Validation
{
    public class AlbumDTOValidator : AbstractValidator<AlbumDTO>
    {
        public AlbumDTOValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Author)
                .NotEmpty()
                .MaximumLength(50);

            RuleFor(e => e.Year)
                .NotNull()
                .LessThanOrEqualTo(DateTime.Now.Year)
                .GreaterThanOrEqualTo(1970);
        }
    }
}
