using System;
using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL
{
    public partial class MusicPlaylists : IEntity
    {
        public int Id { get; set; }
        public int UserPlaylistId { get; set; }
        public int MusicId { get; set; }

        public virtual Music Music { get; set; }
        public virtual UserPlaylists UserPlaylist { get; set; }
    }
}
