using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IMusicPlaylistsService
    {
        Task<IEnumerable<MusicPlaylists>> GetAll();

        Task<MusicPlaylists> Get(int Id);

        Task Add(MusicPlaylists playlist);

        Task Update(MusicPlaylists playlist);
        
        Task Delete(MusicPlaylists playlist);
    }
}
