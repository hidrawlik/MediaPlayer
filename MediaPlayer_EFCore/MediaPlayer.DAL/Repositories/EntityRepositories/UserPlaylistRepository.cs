using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class UserPlaylistRepository : GenericRepository<UserPlaylist>, IUserPlaylistRepository
    {
        public UserPlaylistRepository(MediaDBContext db)
            :base(db)
        {
        }
    }
}
