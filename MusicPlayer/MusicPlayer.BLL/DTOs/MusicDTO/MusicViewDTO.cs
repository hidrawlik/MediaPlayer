using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.DTOs
{
    public class MusicViewDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public byte[] Photo { get; set; }
    }
}
