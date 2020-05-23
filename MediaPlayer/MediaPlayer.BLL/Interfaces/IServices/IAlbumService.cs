using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IAlbumService
    {
        Task<IEnumerable<AlbumDTO>> GetAllAlbums();

        Task<AlbumDTO> GetAlbum(int Id);

        Task AddAlbum(AlbumDTO albumDTO);

        Task UpdateAlbum(AlbumDTO albumDTO);

        Task DeleteAlbum(AlbumDTO albumDTO);

        Task<AlbumDTO> GetAlbum(string Name, string Author);

        Task<IEnumerable<AlbumDTO>> GetAuthorAlbums(string Author);
    }
}
