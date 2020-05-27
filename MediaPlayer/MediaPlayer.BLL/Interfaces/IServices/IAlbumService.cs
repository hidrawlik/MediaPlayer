using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDTO>> GetAllAlbumsAsync();

        Task<AlbumDTO> GetAlbumAsync(int Id);

        Task AddAlbumAsync(AlbumDTO albumDTO);

        Task UpdateAlbumAsync(AlbumDTO albumDTO);

        Task DeleteAlbumAsync(int Id);

        Task<AlbumDTO> GetAlbumAsync(string Name, string Author);

        Task<IEnumerable<AlbumDTO>> GetAuthorAlbumsAsync(string Author);

        Task<bool> IsAnyAlbumDefinedAsync(int Id);
    }
}
