using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.MusicDTO
{
    public class MusicViewDTO
    {
        protected bool _forSixteenYearOlds;

        public string Name { get; set; }
        public string Author { get; set; }
        public int? Year { get; set; }
        public byte[] Photo { get; set; }
        public bool ForSixteenYearOlds
        {
            get
            {
                return _forSixteenYearOlds; 
            }
        }
    }
}
