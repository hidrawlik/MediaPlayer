using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.DTOs
{
    public class UserCreateDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
