using FluentValidation;
using MediaPlayer.BLL.DTOs.MusicDTO;
using System;

namespace MediaPlayer.BLL.Validation
{
    public class MusicCUDTOValidator : AbstractValidator<MusicCUDTO>
    {
        public MusicCUDTOValidator()
        {
            RuleFor(e => e.Name)
                .NotEmpty().WithMessage("The Name cannot be empty")
                .MaximumLength(50).WithMessage("The Name cannot be longer than 50 characters");

            RuleFor(e => e.Author)
                .NotEmpty().WithMessage("The Author's name  cannot be empty")
                .Length(2, 50).WithMessage("Length of Author's name must be between 2 and 50 characters");

            RuleFor(e => e.Year)
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("Year must be less than or equal to " + DateTime.Now.Year)
                .GreaterThanOrEqualTo(1970).WithMessage("Year must be greater than or equal to " + 1970);
        }
    }
}
