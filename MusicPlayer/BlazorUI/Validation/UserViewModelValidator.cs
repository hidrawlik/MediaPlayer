using BlazorUI.Models.AccountModels;
using FluentValidation;

namespace BlazorUI.Validation
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(e => e.email)
                .NotNull()
                .EmailAddress();

            RuleFor(e => e.password)
                .NotEmpty();
        }
    }
}
