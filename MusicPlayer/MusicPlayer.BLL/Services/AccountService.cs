using AutoMapper;
using MusicPlayer.BLL.DTOs;
using MusicPlayer.BLL.Interfaces.IServices;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Services
{
    public class AccountService : SetOfFields, IAccountService
    {
        public AccountService(IUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        {
        }

        public async Task<IdentityResult> RegisterUserAsync(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);

            user.NormalizedEmail = unitOfWork.UserManager.NormalizeEmail(userDTO.Email);

            user.NormalizedUserName = unitOfWork.UserManager.NormalizeName(userDTO.UserName);

            var result = await unitOfWork.UserManager.CreateAsync(user, userDTO.Password);

            if(result.Succeeded)
            {
                await unitOfWork.SignInManager.SignInAsync(user, false);
            }

            return result;
        }

        public async Task<SignInResult> SignInUserAsync(UserLoginDTO userDTO)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(userDTO.Email);
            try
            {
                var result = await unitOfWork.SignInManager.PasswordSignInAsync(user, userDTO.Password, userDTO.RememberMe, false);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public async Task SignOutUserAsync()
        {
            await unitOfWork.SignInManager.SignOutAsync();
        }

        public async Task<UserDTO> GetUserByEmailAsync(string Email)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(Email);

            return mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> GetUserByIdAsync(string Id)
        {
            var user = await unitOfWork.UserManager.FindByIdAsync(Id);

            return mapper.Map<UserDTO>(user);
        }
        public async Task<UserDTO> GetUserByUsernameAsync(string UserName)
        {
            var user = await unitOfWork.UserManager.FindByNameAsync(UserName);

            return mapper.Map<UserDTO>(user);
        }

        #region Поки не потрібно
        //public async Task DeleteUserAsync(UserViewDTO userDTO)
        //{
        //    var user = await unitOfWork.UserManager.FindByIdAsync(userDTO.Id);

        //    await unitOfWork.UserManager.DeleteAsync(user);
        //}
        //public async Task<List<UserViewDTO>> GetAllUsersAsync()
        //{
        //    var userList = await unitOfWork.UserManager.Users.ToListAsync();

        //    return mapper.Map<List<UserViewDTO>>(userList);
        //}

        //public async Task<UserUpdateDTO> GetUserForUpdateAsync(string Id)
        //{
        //    var user = await unitOfWork.UserManager.FindByIdAsync(Id);

        //    return mapper.Map<UserUpdateDTO>(user);
        //}
        //public async Task<IdentityResult> UpdateUserAsync(string Id, UserUpdateDTO userDTO)
        //{
        //    var user = mapper.Map<User>(userDTO);
        //    user.Id = Id;
        //    if (!string.IsNullOrEmpty(userDTO.NewPassword))
        //    {
        //        var res = await unitOfWork.UserManager.ChangePasswordAsync(user, userDTO.CurrentPassword, userDTO.NewPassword);
        //        if (!res.Succeeded)
        //        {
        //            return res;
        //        }
        //    }
        //    user.NormalizedEmail = unitOfWork.UserManager.NormalizeEmail(userDTO.Email);
        //    user.NormalizedUserName = unitOfWork.UserManager.NormalizeName(userDTO.UserName);
        //    var result = await unitOfWork.UserManager.UpdateAsync(user);
        //    return result;
        //}
        #endregion

        public async Task<bool> IsEmailUniqueAsync(string Email)
        {
            var user = await unitOfWork.UserManager.FindByEmailAsync(Email);

            if (user == null)
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

        public async Task<bool> CheckUserPasswordAsync(UserDTO userDTO, string password)
        {
            var user = mapper.Map<User>(userDTO);

            return await unitOfWork.UserManager.CheckPasswordAsync(user, password);
        }
    }
}
