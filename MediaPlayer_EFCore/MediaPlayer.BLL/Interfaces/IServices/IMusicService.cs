using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTO;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IMusicService
    {
        Task<IEnumerable<MusicDTO>> GetAllMusic();

        Task<MusicDTO> GetMusic(int? Id);

        Task AddMusic(MusicDTO music);

        Task UpdateMusic(MusicDTO music);
        
        Task DeleteMusic(MusicDTO music);
    }
}
