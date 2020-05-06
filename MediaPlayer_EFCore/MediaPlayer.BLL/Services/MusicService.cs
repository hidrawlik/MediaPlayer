using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.BLL.DTO;
using MediaPlayer.DAL.Entities;
using AutoMapper;

namespace MediaPlayer.BLL.Services
{
    public class MusicService : IMusicService
    {
        private IUnitOfWork unitOfWork;

        public MusicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task AddMusic(MusicDTO musicDto)
        {
            Music music = new Music
            {
                Name = musicDto.Name,
                Author = musicDto.Author,
                Year = musicDto.Year,
                AlbumId = musicDto.AlbumId,
            };
            await unitOfWork.musicRepository.Add(music);
        }

        public async Task DeleteMusic(MusicDTO musicDto)
        {
            Music music = new Music
            {
                Id = musicDto.Id,
                Name = musicDto.Name,
                Author = musicDto.Author,
                Year = musicDto.Year,
                AlbumId = musicDto.AlbumId
            };
            await unitOfWork.musicRepository.Delete(music);
        }

        public async  Task<MusicDTO> GetMusic(int? Id)
        {
            if (Id == null)
            {
                throw new Exception("Не встановлений id пісні");
            }

            Music music = await unitOfWork.musicRepository.Get(Id.Value);
            if (music == null)
            {
                throw new Exception("Not Found");
            }

            return new MusicDTO {
                Id = music.Id,
                AlbumId = music.AlbumId,
                Author = music.Author,
                Name = music.Name,
                Year = music.Year
            };
        }

        public async Task<IEnumerable<MusicDTO>> GetAllMusic()
        {
            IMapper mapper = new MapperConfiguration(cfg => cfg.CreateMap<Music, MusicDTO>()).CreateMapper();
            IEnumerable<Music> musics = await unitOfWork.musicRepository.GetAll();
            return mapper.Map<IEnumerable<Music>, List<MusicDTO>>(musics);
        }
        
        public async Task UpdateMusic(MusicDTO musicDto)
        {
            Music music = await unitOfWork.musicRepository.Get(musicDto.Id);
            if(music == null)
            {
                throw new Exception("Not found");
            }
            await unitOfWork.musicRepository.Update(music);
        }
    }
}
