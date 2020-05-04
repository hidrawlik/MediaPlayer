using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IUserPlaylistService
    {
        Task<IEnumerable<UserPlaylist>> GetAll();

        Task<UserPlaylist> Get(int Id);

        Task Add(UserPlaylist userPlaylist);

        Task Update(UserPlaylist userPlaylist);
        
        Task Delete(UserPlaylist userPlaylist);
    }
}
