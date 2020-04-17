using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Repositories
{
    public class UserPlaylistsRepository : GenericRepository<UserPlaylists>, IUserPlaylistsRepository
    {
        public UserPlaylistsRepository(MediaDBContext db)
            :base(db)
        {
        }
    }
}
