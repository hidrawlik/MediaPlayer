using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.UserDTO
{
    public class UserEditDTO
    {
        public UserEditDTO() { }

        public UserEditDTO(string Id)
        {
            id = Id;
        }

        private readonly string id;

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
    }
}
