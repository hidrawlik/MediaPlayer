using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs.MusicDTO;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IMusicService
    {
        Task<IEnumerable<MusicViewDTO>> GetAllMusicAsync();

        Task<MusicViewDTO> GetMusicForViewAsync(int? Id);

        Task<MusicCUDTO> GetMusicForUpdateAsync(int? Id);

        Task<MusicCUDTO> GetMusicForUpdateAsync(string Name, string Author, int? Year);

        Task<IEnumerable<MusicViewDTO>> GetMusicByNameAsync(string Name);

        Task AddMusicAsync(MusicCUDTO musicCreateDTO);

        Task UpdateMusicAsync(MusicCUDTO musicUpdateDTO);
        
        Task DeleteMusicAsync(MusicViewDTO musicDTO);
    }
}
