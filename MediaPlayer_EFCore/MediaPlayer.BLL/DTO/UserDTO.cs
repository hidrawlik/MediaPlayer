using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
