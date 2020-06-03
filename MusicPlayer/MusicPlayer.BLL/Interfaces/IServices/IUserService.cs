using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.DTOs.UserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IdentityResult> AddUserAsync(UserCreateDTO userDTO);

        Task DeleteUserAsync(UserViewDTO userDTO);

        Task<List<UserViewDTO>> GetAllUsersAsync();

        Task<UserViewDTO> GetUserByIdAsync(string Id);

        Task<UserViewDTO> GetUserByUsernameAsync(string Username);

        Task<UserViewDTO> GetUserByEmailAsync(string Email);

        Task<UserUpdateDTO> GetUserForUpdateAsync(string Id);

        Task<IdentityResult> UpdateUserAsync(string Id, UserUpdateDTO userDTO);

        Task<bool> IsEmailUniqueAsync(string Email);

        Task<bool> IsUserNameUniqueAsync(string userName);

        Task<bool> CheckPassword(string UserId, string password);
    }
}
