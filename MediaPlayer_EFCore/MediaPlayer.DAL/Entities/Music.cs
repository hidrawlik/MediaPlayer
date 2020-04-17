using System;
using System.Collections.Generic;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL
{
    public partial class Music : IEntity
    {
        public Music()
        {
            MusicPlaylists = new HashSet<MusicPlaylists>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int Year { get; set; }
        public string Album { get; set; }

        public virtual ICollection<MusicPlaylists> MusicPlaylists { get; set; }
    }
}
