using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public int? AlbumId { get; set; }
        public byte Photo { get; set; }
    }
}
