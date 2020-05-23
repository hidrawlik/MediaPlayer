using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.DAL.Entities;
using System.Linq;
using MediaPlayer.BLL.Validation;
using FluentValidation;

namespace MediaPlayer.BLL.Services
{
    public class MusicService : SetOfFields, IMusicService
    {
        private readonly IValidator<MusicCUDTO> validationRules;

        public MusicService(IUnitOfWork unitOfWork,
            IValidator<MusicCUDTO> validationRules)
            : base(unitOfWork)
        {
            this.validationRules = validationRules;
        }

        public async Task<IEnumerable<MusicViewDTO>> GetMusicByNameAsync(string Name)
        {
            var musicList = await unitOfWork.MusicRepository.GetByName(Name);

            return mapper.Map<List<MusicViewDTO>>(musicList);
        }
        public async Task<MusicViewDTO> GetMusicForViewAsync(int? Id)
        {
            if (Id == null)
            {
                throw new Exception("Не встановлений id пісні");
            }

            var music = await unitOfWork.MusicRepository.Get(Id.Value);

            return mapper.Map<MusicViewDTO>(music);
        }
        public async Task<IEnumerable<MusicViewDTO>> GetAllMusicAsync()
        {
            IEnumerable<Music> musics = await unitOfWork.MusicRepository.GetAll();
            return mapper.Map<IEnumerable<MusicViewDTO>>(musics);
        }

        public async Task UpdateMusicAsync(MusicCUDTO musicEditDTO)
        {
            var result = validationRules.Validate(musicEditDTO);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }

            var music = mapper.Map<Music>(musicEditDTO);

            await unitOfWork.MusicRepository.Update(music);
        }
        public async Task<MusicCUDTO> GetMusicForUpdateAsync(int? Id)
        {
            if (Id == null)
            {
                throw new Exception("Не встановлений id пісні");
            }

            var music = await unitOfWork.MusicRepository.Get(Id.Value);

            return await ToFillMusicCUDTORecordsAsync(music);
        }
        public async Task<MusicCUDTO> GetMusicForUpdateAsync(string Name, string Author, int? Year)
        {
            var music = await unitOfWork.MusicRepository.Get(Name, Author, Year);

            return await ToFillMusicCUDTORecordsAsync(music);
        }
        public async Task AddMusicAsync(MusicCUDTO musicCreateDTO)
        {
            var result = validationRules.Validate(musicCreateDTO);

            if (!result.IsValid)
            {
                throw new Exception(result.ToString());
            }

            var music = mapper.Map<Music>(musicCreateDTO);

            if (musicCreateDTO.Album != null)
            {
                var album = await unitOfWork.AlbumRepository.Get(musicCreateDTO.Album, musicCreateDTO.Author);

                if (album != null)
                {
                    music.AlbumId = album.Id;
                }
            }

            await unitOfWork.MusicRepository.Add(music);

            if (musicCreateDTO.Genre != null)
            {
                var genre = await unitOfWork.GenreRepository.GetByName(musicCreateDTO.Genre);

                if (genre != null)
                {
                    music = await unitOfWork.MusicRepository.Get(music.Name, music.Author, music.Year);

                    MusicGenre musicGenre = new MusicGenre
                    {
                        GenreId = genre.Id,
                        MusicId = music.Id
                    };

                    await unitOfWork.MusicGenreRepository.Add(musicGenre);
                }
            }
        }
        public async Task DeleteMusicAsync(MusicViewDTO musicDTO)
        {
            var music = await unitOfWork.MusicRepository.Get(musicDTO.Name, musicDTO.Author, musicDTO.Year);

            await unitOfWork.MusicRepository.Delete(music);
        }

        private async Task<MusicCUDTO> ToFillMusicCUDTORecordsAsync(Music music)
        {
            var musicDTO = mapper.Map<MusicCUDTO>(music);

            if (musicDTO == null)
            {
                return musicDTO;
            }

            if (music.AlbumId != null)
            {
                var album = await unitOfWork.AlbumRepository.Get(music.AlbumId.Value);

                musicDTO.Album = album.Name;

                if (musicDTO.Album == null)
                {
                    musicDTO.Album = "";
                }
            }

            music.MusicGenres = await unitOfWork.MusicGenreRepository.GetByMusicId(music.Id);

            if (music.MusicGenres != null)
            {
                foreach (var item in music.MusicGenres)
                {
                    item.Genre = await unitOfWork.GenreRepository.Get(item.GenreId);
                }

                int i = 0;
                foreach (var item in music.MusicGenres)
                {
                    if (i < music.MusicGenres.Count() - 1)
                    {
                        musicDTO.Genre += item.Genre.Name + ", ";
                    }
                    else
                    {
                        musicDTO.Genre += item.Genre.Name;
                    }
                    i++;
                }
            }

            if (musicDTO.Genre == null)
            {
                musicDTO.Genre = "";
            }

            return musicDTO;
        }
    }
}
