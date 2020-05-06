using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(MediaDBContext db)
            : base(db)
        {
        }
    }
}
