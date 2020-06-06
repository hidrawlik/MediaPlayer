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
    public class MusicPlaylistRepository : GenericRepository<MusicPlaylist>, IMusicPlaylistRepository
    {
        public MusicPlaylistRepository(MusicDBContext db) 
            : base (db)
        {
        }

        public async Task<IEnumerable<MusicPlaylist>> GetAll(int UserPlaylistId)
        {
            return await db.Set<MusicPlaylist>().Where(e => e.UserPlaylistId.Equals(UserPlaylistId)).ToListAsync();
        }

        public async Task<MusicPlaylist> GetByUserPlaylistIdAndMusicId(int UserPlaylistId, int MusicId)
        {
            return await db.Set<MusicPlaylist>().Where(e => e.UserPlaylistId.Equals(UserPlaylistId) && e.MusicId.Equals(MusicId)).FirstOrDefaultAsync();
        }
    }
}
