using FluentValidation;
using MusicPlayer.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.Validation
{
    public class MusicPlaylistDTOValidator : AbstractValidator<MusicPlaylistDTO>
    {
        public MusicPlaylistDTOValidator()
        {
            RuleFor(e => e.MusicId)
                .NotNull();

            RuleFor(e => e.UserPlaylistId)
                .NotNull();
        }
    }
}
