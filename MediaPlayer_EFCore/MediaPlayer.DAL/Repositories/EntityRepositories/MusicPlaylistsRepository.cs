using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Repositories
{
    public class MusicPlaylistsRepository : GenericRepository<MusicPlaylists>, IMusicPlaylistsRepository
    {
        public MusicPlaylistsRepository(MediaDBContext db)
            :base(db)
        {
        }
    }
}

