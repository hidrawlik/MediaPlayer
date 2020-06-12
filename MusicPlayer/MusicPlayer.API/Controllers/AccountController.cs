using System.Threading.Tasks;
using MusicPlayer.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;
using MusicPlayer.BLL.DTOs;
using System;

namespace MusicPlayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;
        private readonly JWT jwt;

        public AccountController(IAccountService accountService,
            JWT jwt)
        {
            this.accountService = accountService;
            this.jwt = jwt;
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("Registration")]
        [HttpPost]
        public async Task<ActionResult<UserDTO>> RegisterUser([FromBody]UserDTO userDTO)
        {
            if (!await accountService.IsEmailUniqueAsync(userDTO.Email))
            {
                ModelState.AddModelError("Email", "Email вже використовується");
            }

            if (!await accountService.IsUserNameUniqueAsync(userDTO.UserName))
            {
                ModelState.AddModelError("UserName", "Дане ім'я вже використовується");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await accountService.RegisterUserAsync(userDTO);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return BadRequest(ModelState);
            }

            var user = await accountService.GetUserByEmailAsync(userDTO.Email);
            return Ok(jwt.GenerateJwtToken(user.Email, user));
        }

        /// <summary>
        /// Log in
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [Route("Login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]UserLoginDTO userDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await accountService.SignInUserAsync(userDTO);

            if (result != null && result.Succeeded)
            {
                var user = await accountService.GetUserByEmailAsync(userDTO.Email);
                return Ok(jwt.GenerateJwtToken(user.Email, user));
            }

            ModelState.AddModelError(string.Empty, "Invalid Login or Password");
            return BadRequest(ModelState);
        }

        /// <summary>
        /// Logout
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await accountService.SignOutUserAsync();
            return Ok();
        }

        //[ValidateAntiForgeryToken]
    }
}
