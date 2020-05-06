using MediaPlayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Entities
{
    public class Album : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public byte[] Photo { get; set; }

        public ICollection<Music> Musics { get; set; }
    }
}
