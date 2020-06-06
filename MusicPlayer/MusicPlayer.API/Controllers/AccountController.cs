//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using MusicPlayer.BLL.Interfaces.IServices;
//using Microsoft.AspNetCore.Mvc;

//namespace MusicPlayer.API.Controllers
//{
//    [Route("api/[controller]")]
//    public class AccountController : Controller
//    {
//        private readonly IUserService userService;
//        private readonly SignInManager<User> _signInManager;

//        public AccountController(IUserService userService, SignInManager<User> signInManager)
//        {
//            this.userService = userService;
//            _signInManager = signInManager;
//        }
//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }
//        [HttpPost]
//        public async Task<IActionResult> Register(RegisterViewModel model)
//        {
//            if (ModelState.IsValid)
//            {
//                User user = new User { Email = model.Email, UserName = model.Email, Year = model.Year };
//                // добавляем пользователя
//                var result = await _userManager.CreateAsync(user, model.Password);
//                if (result.Succeeded)
//                {
//                    // установка куки
//                    await _signInManager.SignInAsync(user, false);
//                    return RedirectToAction("Index", "Home");
//                }
//                else
//                {
//                    foreach (var error in result.Errors)
//                    {
//                        ModelState.AddModelError(string.Empty, error.Description);
//                    }
//                }
//            }
//            return View(model);
//        }
//    }
//}
