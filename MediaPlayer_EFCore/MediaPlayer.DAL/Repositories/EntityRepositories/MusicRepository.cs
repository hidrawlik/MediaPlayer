using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Repositories
{
    public class MusicRepository : GenericRepository<Music>, IMusicRepository
    {
        public MusicRepository(MediaDBContext db)
            : base(db)
        {
        }
    }
}
