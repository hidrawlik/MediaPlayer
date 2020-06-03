using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

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
