using MusicPlayer.DAL.EFCoreContexts;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Repositories.EntityRepositories
{
    public class UserPlaylistRepository : GenericRepository<UserPlaylist>, IUserPlaylistRepository
    {
        public UserPlaylistRepository(MusicDBContext db)
            : base (db)
        {
        }

        public async Task<UserPlaylist> Get(string UserId, string PlaylistName)
        {
            return await db.Set<UserPlaylist>().Where(e => e.UserId.Equals(UserId) && e.PlaylistName.Equals(PlaylistName)).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<UserPlaylist>> GetByUserId(string UserId)
        {
            return await db.Set<UserPlaylist>().Where(e => e.UserId == UserId).ToListAsync();
        }
    }
}
