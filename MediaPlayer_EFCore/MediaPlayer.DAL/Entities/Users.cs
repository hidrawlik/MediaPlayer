using System;
using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL
{
    public partial class Users : IEntity
    {
        public Users()
        {
            UserPlaylists = new HashSet<UserPlaylists>();
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual ICollection<UserPlaylists> UserPlaylists { get; set; }
    }
}
