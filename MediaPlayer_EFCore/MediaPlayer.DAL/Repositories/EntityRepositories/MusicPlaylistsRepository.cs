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

