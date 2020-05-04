using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTO
{
    public class MusicDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupName { get; set; }
        public int Year { get; set; }
        public string Album { get; set; }
    }
}
