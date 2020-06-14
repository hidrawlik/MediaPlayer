using BlazorUI.Models.AccountModels;
using System.Threading.Tasks;

namespace BlazorUI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<RegisterViewModel> RegisterUserAsync(RegisterViewModel user);

        Task<UserViewModel> AuthenticateUserAsync(UserViewModel userParams);
    }
}
