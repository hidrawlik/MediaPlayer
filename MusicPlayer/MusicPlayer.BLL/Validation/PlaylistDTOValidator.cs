using FluentValidation;
using MusicPlayer.BLL.DTOs;

namespace MusicPlayer.BLL.Validation
{
    public class PlaylistDTOValidator : AbstractValidator<PlaylistDTO>
    {
        public PlaylistDTOValidator()
        {
            RuleFor(e => e.UserId)
                .NotEmpty();

            RuleFor(e => e.PlaylistName)
                .MinimumLength(2)
                .MaximumLength(50);
        }
    }
}
