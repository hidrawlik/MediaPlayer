using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IMusicPlaylistRepository : IGenericRepository<MusicPlaylist>
    {
        Task<IEnumerable<MusicPlaylist>> GetAll(int UserPlaylistId);
        Task<MusicPlaylist> GetByUserPlaylistIdAndMusicId(int UserPlaylistId, int MusicId);
    }
}
