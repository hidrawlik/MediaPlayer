using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.MusicDTO
{
    public class MusicCUDTO : MusicViewDTO
    {
        public int Id { get; set; }
        public string Genre { get; set; }
        public string Album { get; set; }

        public void SetAgeRestrictions(bool value)
        {
            _forSixteenYearOlds = value;
        }
    }
}
