using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.BLL.DTOs
{
    public class MusicViewDTO
    {
        protected bool _forSixteenYearOlds;
       
        public int Id { get; set; }
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
