using MusicPlayer.BLL.DTOs;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Interfaces.IServices
{
    public interface IAccountService
    {
        Task<IdentityResult> RegisterUserAsync(UserDTO user);

        Task<SignInResult> SignInUserAsync(UserLoginDTO userDTO);

        Task SignOutUserAsync();

        //Task DeleteUserAsync(UserViewDTO userDTO);

        //Task<List<UserViewDTO>> GetAllUsersAsync();

        Task<UserDTO> GetUserByIdAsync(string Id);

        Task<UserDTO> GetUserByUsernameAsync(string Username);

        Task<UserDTO> GetUserByEmailAsync(string Email);

        //Task<UserUpdateDTO> GetUserForUpdateAsync(string Id);

        //Task<IdentityResult> UpdateUserAsync(string Id, UserUpdateDTO userDTO);

        Task<bool> IsEmailUniqueAsync(string Email);

        Task<bool> IsUserNameUniqueAsync(string userName);

        Task<bool> CheckUserPasswordAsync(UserDTO user, string password);
    }
}
