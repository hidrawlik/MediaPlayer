using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.DTOs
{
    public class MusicCUDTO : MusicViewDTO
    {
        public string Genre { get; set; }
        public string Album { get; set; }

        public void SetAgeRestrictions(bool value)
        {
            ForSixteenYearOlds = value;
        }
    }
}
