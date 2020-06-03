using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class UserPlaylistRepository : GenericRepository<UserPlaylist>, IUserPlaylistRepository
    {
        public UserPlaylistRepository(MusicDBContext db)
            : base (db)
        {
        }
    }
}
