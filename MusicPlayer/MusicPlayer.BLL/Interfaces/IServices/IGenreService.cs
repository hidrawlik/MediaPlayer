using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAllGenresAsync();

        Task<GenreDTO> GetGenreAsync(int Id);

        Task<GenreDTO> GetGenreAsync(string Name);

        Task AddGenreAsync(GenreDTO genreDTO);

        Task UpdateGenreAsync(GenreDTO genreDTO);

        Task DeleteGenreAsync(int Id);

        Task<bool> IsAnyGenreDefinedAsync(int Id);
    }
}
