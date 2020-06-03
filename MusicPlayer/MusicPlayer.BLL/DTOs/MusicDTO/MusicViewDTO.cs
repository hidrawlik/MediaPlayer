using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.BLL.DTOs.MusicDTO
{
    public class MusicViewDTO
    {
        public MusicViewDTO() { }

        public MusicViewDTO(int Id)
        {
            id = Id;
        }

        private readonly int id = 0;
        protected bool _forSixteenYearOlds;

        public int Id {
            get
            {
                return id;
            }
        }
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

            protected set
            {
                _forSixteenYearOlds = value;
            }
        }
    }
}
