using System;
using System.Collections.Generic;
using MusicPlayer.DAL.Interfaces;

namespace MusicPlayer.DAL.Entities
{
    public partial class Music : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public int? AlbumId { get; set; }
        public byte[] Photo { get; set; }

        public Album Album { get; set; }
        public virtual ICollection<MusicPlaylist> MusicPlaylists { get; set; }
        public virtual ICollection<MusicGenre> MusicGenres { get; set; }
    }
}
