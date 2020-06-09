using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace MusicPlayer.DAL.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Photo { get; set; }

        public virtual ICollection<UserPlaylist> UserPlaylists { get; set; }
    }
}
