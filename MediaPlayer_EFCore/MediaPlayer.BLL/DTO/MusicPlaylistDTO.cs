using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTO
{
    public class MusicPlaylistDTO
    {
        public int Id { get; set; }
        public int UserPlaylistId { get; set; }
        public int MusicId { get; set; }
    }
}
