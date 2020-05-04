using System;
using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Entities
{
    public partial class User : IEntity
    {
        public User()
        {
            UserPlaylists = new HashSet<UserPlaylist>();
        }

        public int Id { get; set; }
        public string NickName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public virtual ICollection<UserPlaylist> UserPlaylists { get; set; }
    }
}
