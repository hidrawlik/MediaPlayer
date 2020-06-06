using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IUserPlaylistRepository : IGenericRepository<UserPlaylist>
    {
        Task<IEnumerable<UserPlaylist>> GetByUserId(string UserId);

        Task<UserPlaylist> Get(string UserId, string PlaylistName);
    }
}
