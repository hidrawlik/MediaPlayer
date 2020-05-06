using MediaPlayer.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Entities
{
    public class Admin : IEntity
    {
        public int StatusCode { get; set; }

        public int Id { get; set; }
        public virtual User User { get; set; }
    }
}
