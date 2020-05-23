using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreDTO>> GetAll();

        Task<GenreDTO> Get(int Id);

        Task Add(GenreDTO genreDTO);

        Task Update(GenreDTO genreDTO);

        Task Delete(GenreDTO genreDTO);
    }
}
