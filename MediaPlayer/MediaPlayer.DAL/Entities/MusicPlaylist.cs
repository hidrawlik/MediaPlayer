using MediaPlayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Entities
{
    public class MusicPlaylist : IEntity
    {
        public int Id { get; set; }
        public int UserPlaylistId { get; set; }
        public int MusicId { get; set; }

        public virtual Music Music { get; set; }
        public virtual UserPlaylist UserPlaylist { get; set; }
    }
}
