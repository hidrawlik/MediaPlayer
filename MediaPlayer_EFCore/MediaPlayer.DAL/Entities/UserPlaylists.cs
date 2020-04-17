using System;
using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL
{
    public partial class UserPlaylists : IEntity
    {
        public UserPlaylists()
        {
            MusicPlaylists = new HashSet<MusicPlaylists>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string PlaylistName { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<MusicPlaylists> MusicPlaylists { get; set; }
    }
}
