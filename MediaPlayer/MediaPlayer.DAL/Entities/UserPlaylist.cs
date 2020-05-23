using MediaPlayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Entities
{
    public class UserPlaylist : IEntity
    {
        public UserPlaylist()
        {
            MusicPlaylists = new HashSet<MusicPlaylist>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string PlaylistName { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<MusicPlaylist> MusicPlaylists { get; set; }
    }
}
