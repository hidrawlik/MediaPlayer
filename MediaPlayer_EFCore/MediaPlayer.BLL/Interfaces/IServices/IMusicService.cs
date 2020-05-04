using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL;

namespace MediaPlayer.BLL.Interfaces
{
    public interface IMusicService
    {
        Task<IEnumerable<Music>> GetAll();

        Task<Music> Get(int Id);

        Task Add(Music music);

        Task Update(Music music);
        
        Task Delete(Music music);
    }
}
