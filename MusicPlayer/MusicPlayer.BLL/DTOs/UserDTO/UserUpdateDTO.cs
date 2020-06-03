using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.UserDTO
{
    public class UserUpdateDTO
    {
        public UserUpdateDTO() { }

        public UserUpdateDTO(string Id)
        {
            id = Id;
        }

        private readonly string id = "-1";

        public string Id
        {
            get
            {
                return id;
            }
        }

        public string UserName { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public byte[] Photo { get; set; }
    }
}
