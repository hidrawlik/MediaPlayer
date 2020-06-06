using System.Collections.Generic;
using MusicPlayer.DAL.Interfaces;

namespace MusicPlayer.DAL.Entities
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MusicGenre> MusicGenres { get; set; }
    }
}
