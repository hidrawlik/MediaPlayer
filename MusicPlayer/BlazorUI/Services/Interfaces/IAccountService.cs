using BlazorUI.Models.AccountModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorUI.Services.Interfaces
{
    public interface IAccountService
    {
        Task<List<string>> RegisterUserAsync(RegisterViewModel user);

        Task<UserViewModel> AuthenticateUserAsync(UserLoginModel userParams);
    }
}
