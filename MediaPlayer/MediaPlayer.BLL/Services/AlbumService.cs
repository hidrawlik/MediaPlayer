using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;
using MediaPlayer.BLL.DTOs;

namespace MediaPlayer.BLL.Services
{
    public class AlbumService : SetOfFields, IAlbumService
    {
        public AlbumService(IUnitOfWork unitOfWork)
           : base(unitOfWork)
        {
        }

        public async Task AddAlbum(AlbumDTO albumDTO)
        {
            var album = mapper.Map<Album>(albumDTO);

            await unitOfWork.AlbumRepository.Add(album);
        }

        public async Task DeleteAlbum(AlbumDTO albumDTO)
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

        public async Task<AlbumDTO> GetAlbum(int Id)
        {
            var album = await unitOfWork.AlbumRepository.Get(Id);

            if (album == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<AlbumDTO>(album);
        }

        public async Task<AlbumDTO> GetAlbum(string Name, string Author)
        {
            var album = await unitOfWork.AlbumRepository.Get(Name, Author);

            if (album == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<AlbumDTO>(album);
        }

        public async Task<IEnumerable<AlbumDTO>> GetAllAlbums()
        {
            var albums = await unitOfWork.AlbumRepository.GetAll();

            if (albums == null)
            {
                throw new Exception("Not found");
            }

            return mapper.Map<IEnumerable<AlbumDTO>>(albums);
        }

        public async Task<IEnumerable<AlbumDTO>> GetAuthorAlbums(string Author)
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

        public async Task UpdateAlbum(AlbumDTO albumDTO)
        {
            var album = mapper.Map<Album>(albumDTO);

            await unitOfWork.AlbumRepository.Update(album);
        }
    }
}
