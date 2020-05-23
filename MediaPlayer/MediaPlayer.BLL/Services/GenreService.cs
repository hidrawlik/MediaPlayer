using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Services
{
    public class GenreService : SetOfFields, IGenreService
    {
        public GenreService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public async Task Add(GenreDTO genreDTO)
        {
            var genre = mapper.Map<Genre>(genreDTO);

            await unitOfWork.GenreRepository.Add(genre);
        }

        public async Task Delete(GenreDTO genreDTO)
        {
            var genre = mapper.Map<Genre>(genreDTO);

            await unitOfWork.GenreRepository.Delete(genre);
        }

        public async Task<GenreDTO> Get(int Id)
        {
            var genre = await unitOfWork.GenreRepository.Get(Id);

            return mapper.Map<GenreDTO>(genre);
        }

        public async Task<IEnumerable<GenreDTO>> GetAll()
        {
            var genreList = await unitOfWork.GenreRepository.GetAll();

            return mapper.Map<IEnumerable<GenreDTO>>(genreList);
        }

        public async Task Update(GenreDTO genreDTO)
        {
            var genre = mapper.Map<Genre>(genreDTO);

            await unitOfWork.GenreRepository.Update(genre);
        }
    }
}
