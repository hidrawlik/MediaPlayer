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

        Task AddGenreAsync(GenreDTO genreDTO);

        Task UpdateGenreAsync(GenreDTO genreDTO);

        Task DeleteGenreAsync(GenreDTO genreDTO);
    }
}
