using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IUserPlaylistsService
    {
        Task<IEnumerable<UserPlaylists>> GetAll();

        Task<UserPlaylists> Get(int Id);

        Task Add(UserPlaylists userPlaylist);

        Task Update(UserPlaylists userPlaylist);
        
        Task Delete(UserPlaylists userPlaylist);
    }
}
