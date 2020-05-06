using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class MusicRepository : GenericRepository<Music>, IMusicRepository
    {
        public MusicRepository(MediaDBContext db)
            : base(db)
        {
        }
    }
}
