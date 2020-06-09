using System.Collections.Generic;
using System.Threading.Tasks;
using MusicPlayer.BLL.DTOs;
using MusicPlayer.BLL.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace MusicPlayer.WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewDTO>>> Get()
        {
            var userDTOList = await userService.GetAllUsersAsync();

            if (userDTOList == null)
            {
                return NotFound();
            }

            return Ok(userDTOList);
        }

        /// <summary>
        /// GetForViewById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewDTO>> Get(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var userDTO = await userService.GetUserByIdAsync(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return Ok(userDTO);
        }

        /// <summary>
        /// GetForUpdateById
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("update/{Id}")]
        public async Task<ActionResult<UserUpdateDTO>> GetForUpdate(string Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }

            var userDTO = await userService.GetUserForUpdateAsync(Id);

            if (userDTO == null)
            {
                return NotFound();
            }

            return Ok(userDTO);
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]UserCreateDTO userDTO)
        {
            if (!await userService.IsEmailUniqueAsync(userDTO.Email))
            {
                ModelState.AddModelError("Email", "Email вже використовується");
            }

            if (!await userService.IsUserNameUniqueAsync(userDTO.UserName))
            {
                ModelState.AddModelError("UserName", "Дане ім'я вже використовується");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await userService.CreateUserAsync(userDTO);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return Ok(userDTO);
        }

        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userDTO"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]UserUpdateDTO userDTO)
        {
            if (id == null || userDTO == null)
            {
                return BadRequest();
            }

            if (!await userService.IsEmailUniqueAsync(userDTO.Email))
            {
                ModelState.AddModelError("Email", "Email вже використовується");
            }

            if (!await userService.IsUserNameUniqueAsync(userDTO.UserName))
            {
                ModelState.AddModelError("UserName", "Дане ім'я вже використовується");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await userService.UpdateUserAsync(id, userDTO);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Ok(result);
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            var userDTO = await userService.GetUserByIdAsync(id);

            if (userDTO == null)
            {
                return NotFound();
            }

            await userService.DeleteUserAsync(userDTO);
            return NoContent();
        }
    }
}
