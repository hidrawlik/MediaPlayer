using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IMusicPlaylistService
    {
        Task<IEnumerable<MusicPlaylist>> GetAll();

        Task<MusicPlaylist> Get(int Id);

        Task Add(MusicPlaylist playlist);

        Task Update(MusicPlaylist playlist);
        
        Task Delete(MusicPlaylist playlist);
    }
}
