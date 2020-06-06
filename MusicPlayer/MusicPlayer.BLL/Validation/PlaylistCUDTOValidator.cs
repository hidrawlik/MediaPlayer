using FluentValidation;
using MusicPlayer.BLL.DTOs;

namespace MusicPlayer.BLL.Validation
{
    public class PlaylistCUDTOValidator : AbstractValidator<PlaylistCUDTO>
    {
        public PlaylistCUDTOValidator()
        {
            RuleFor(e => e.Name)
                 .MinimumLength(2)
                 .MaximumLength(50);
        }
    }
}
