using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;
using MediaPlayer.BLL.DTOs;
using AutoMapper;

namespace MediaPlayer.BLL.Services
{
    public class AlbumService : SetOfFields, IAlbumService
    {
        public AlbumService(IUnitOfWork unitOfWork, IMapper mapper)
           : base(unitOfWork, mapper)
        {
        }

        public async Task AddAlbumAsync(AlbumDTO albumDTO)
        {
            var album = mapper.Map<Album>(albumDTO);

            await unitOfWork.AlbumRepository.Add(album);
        }

        public async Task DeleteAlbumAsync(AlbumDTO albumDTO)
        {
            var album =  await unitOfWork.AlbumRepository.Get(albumDTO.Name, albumDTO.Author);

            if (album == null)
            {
                throw new Exception("Not found");
            }

            var musicCollection = await unitOfWork.MusicRepository.GetByAlbumId(album.Id);

            foreach(var music in musicCollection)
            {
                music.AlbumId = null;
                await unitOfWork.MusicRepository.Update(music);
            }

            await unitOfWork.AlbumRepository.Delete(album);
        }

        public async Task<AlbumDTO> GetAlbumAsync(int Id)
        {
            var album = await unitOfWork.AlbumRepository.Get(Id);

            if (album == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<AlbumDTO>(album);
        }

        public async Task<AlbumDTO> GetAlbumAsync(string Name, string Author)
        {
            var album = await unitOfWork.AlbumRepository.Get(Name, Author);

            if (album == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<AlbumDTO>(album);
        }

        public async Task<IEnumerable<AlbumDTO>> GetAllAlbumsAsync()
        {
            var albums = await unitOfWork.AlbumRepository.GetAll();

            if (albums == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<AlbumDTO>>(albums);
        }

        public async Task<IEnumerable<AlbumDTO>> GetAuthorAlbumsAsync(string Author)
        {
            if (Author == null)
            {
                throw new Exception("Author's name is null");
            }

            var albums = await unitOfWork.AlbumRepository.GetAuthorAlbums(Author);

            if(albums == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<AlbumDTO>>(albums);
        }

        public async Task UpdateAlbumAsync(AlbumDTO albumDTO)
        {
            var album = mapper.Map<Album>(albumDTO);

            await unitOfWork.AlbumRepository.Update(album);
        }
    }
}
