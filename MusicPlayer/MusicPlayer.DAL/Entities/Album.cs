using System.Collections.Generic;
using MusicPlayer.DAL.Interfaces;

namespace MusicPlayer.DAL.Entities
{
    public class Album : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public string PhotoPath { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
