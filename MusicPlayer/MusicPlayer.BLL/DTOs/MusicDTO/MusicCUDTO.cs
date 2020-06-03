using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.MusicDTO
{
    public class MusicCUDTO : MusicViewDTO
    {
        public MusicCUDTO() { }

        public MusicCUDTO(int Id) : base(Id) { }

        public string Genre { get; set; }
        public string Album { get; set; }

        public void SetAgeRestrictions(bool value)
        {
            ForSixteenYearOlds = value;
        }
    }
}
