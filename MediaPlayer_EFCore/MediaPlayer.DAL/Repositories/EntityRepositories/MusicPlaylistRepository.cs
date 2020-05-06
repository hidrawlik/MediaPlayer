using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class MusicPlaylistRepository : GenericRepository<MusicPlaylist>, IMusicPlaylistRepository
    {
        public MusicPlaylistRepository(MediaDBContext db)
            :base(db)
        {
        }
    }
}

