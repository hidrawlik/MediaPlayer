using AutoMapper;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.DTOs.UserDTO;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.BLL.Services
{
    public class UserService : SetOfFields, IUserService
    {
        public UserService(IUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        {
        }

        public async Task<IdentityResult> AddUserAsync(UserCreateDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            user.NormalizedEmail = unitOfWork.UserManager.NormalizeEmail(userDTO.Email);

            user.NormalizedUserName = unitOfWork.UserManager.NormalizeName(userDTO.UserName);

            return await unitOfWork.UserManager.CreateAsync(user, userDTO.ConfirmPassword);
        }

        public async  Task DeleteUserAsync(UserViewDTO userDTO)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(userDTO.Id);

            await unitOfWork.UserManager.DeleteAsync(user);
        }

        public async Task<List<UserViewDTO>> GetAllUsersAsync()
        {
            var userList = await unitOfWork.UserManager.Users.ToListAsync();

            return mapper.Map<List<UserViewDTO>>(userList);
        }

        public async Task<UserViewDTO> GetUserByEmailAsync(string Email)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(Email);

            return mapper.Map<UserViewDTO>(user);
        }

        public async Task<UserViewDTO> GetUserByIdAsync(string Id)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(Id);

            return mapper.Map<UserViewDTO>(user);
        }

        public async Task<UserViewDTO> GetUserByUsernameAsync(string Username)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(Username);

            return mapper.Map<UserViewDTO>(user);
        }

        public async Task<UserUpdateDTO> GetUserForUpdateAsync(string Id)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(Id);

            return mapper.Map<UserUpdateDTO>(user);
        }

        public async Task<IdentityResult> UpdateUserAsync(string Id, UserUpdateDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            user.Id = Id;

            if (!string.IsNullOrEmpty(userDTO.NewPassword))
            {
                await unitOfWork.UserManager.ChangePasswordAsync(user, userDTO.CurrentPassword, userDTO.NewPassword);
            }

            user.NormalizedEmail = unitOfWork.UserManager.NormalizeEmail(userDTO.Email);

            user.NormalizedUserName = unitOfWork.UserManager.NormalizeName(userDTO.UserName);

            return await unitOfWork.UserManager.UpdateAsync(user);
        }

        public async Task<bool> IsEmailUniqueAsync(string Email)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(Email);

            if(user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> IsUserNameUniqueAsync(string userName)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(userName);

            if (user == null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> CheckPassword(string UserId, string password)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(UserId);
            return await unitOfWork.UserManager.CheckPasswordAsync(user, password);
        }
    }
}
