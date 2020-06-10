using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.DTOs
{
    public class UserViewDTO
    {
        public UserViewDTO(string Id)
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

        public string PhotoPath { get; set; }
    }
}
