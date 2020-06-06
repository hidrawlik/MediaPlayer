using AutoMapper;
using MusicPlayer.BLL.Services;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces;
using MusicPlayer.BLL.DTOs;
using MusicPlayer.BLL.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.BLL.Services
{
    public class PlaylistService : SetOfFields, IPlaylistService
    {
        public PlaylistService(IUnitOfWork unitOfWork,
             IMapper mapper)
             : base(unitOfWork, mapper)
        {
        }

        public async Task AddMusicToPlaylistAsync(MusicPlaylistDTO musicPlaylistDTO)
        {
            var musicPlaylist = mapper.Map<MusicPlaylist>(musicPlaylistDTO);
            await unitOfWork.MusicPlaylistRepository.Add(musicPlaylist);
        }
        public async Task AddPlaylistAsync(string UserId, PlaylistCUDTO playlistDTO)
        {
            var userPlaylist = mapper.Map<UserPlaylist>(playlistDTO);
            userPlaylist.UserId = UserId;
            await unitOfWork.UserPlaylistRepository.Add(userPlaylist);
        }
        public async Task DeleteMusicFromPlaylistAsync(MusicPlaylistDTO musicPlaylistDTO)
        {
            var musicPlaylist = await unitOfWork
                .MusicPlaylistRepository
                    .GetByUserPlaylistIdAndMusicId(
                        musicPlaylistDTO.UserPlaylistId,
                        musicPlaylistDTO.MusicId);

            await unitOfWork.MusicPlaylistRepository.Delete(musicPlaylist);
        }
        public async Task DeletePlaylistAsync(PlaylistDTO playlistDTO)
        {
            var userPlaylist = mapper.Map<UserPlaylist>(playlistDTO);
            await unitOfWork.UserPlaylistRepository.Delete(userPlaylist);
        }
        public async Task<IEnumerable<PlaylistDTO>> GetAllAsync()
        {
            var userPlaylists = await unitOfWork.UserPlaylistRepository.GetAll();
            var PlaylistsDTO = mapper.Map<IEnumerable<PlaylistDTO>>(userPlaylists);
            foreach (var playlist in PlaylistsDTO)
            {
                var musicList = (await unitOfWork.MusicPlaylistRepository.GetAll(playlist.Id)).ToList();
                playlist.MusicList = mapper.Map<IList<MusicViewDTO>>(musicList);
            }
            return PlaylistsDTO;
        }
        public async Task<PlaylistDTO> GetPlaylistAsync(int Id)
        {
            var userPlaylist = await unitOfWork.UserPlaylistRepository.Get(Id);

            var userPlaylistDTO = mapper.Map<PlaylistDTO>(userPlaylist);

            if(userPlaylistDTO == null)
            {
                return userPlaylistDTO;
            }

            var musicList = await unitOfWork.MusicPlaylistRepository.GetAll(userPlaylistDTO.Id);

            userPlaylistDTO.MusicList = mapper.Map<IList<MusicViewDTO>>(musicList);

            return userPlaylistDTO;
        }
        public async Task<PlaylistDTO> GetPlaylistAsync(string UserId, string PlaylistName)
        {
            var userPlaylist = await unitOfWork.UserPlaylistRepository.Get(UserId, PlaylistName);

            var userPlaylistDTO = mapper.Map<PlaylistDTO>(userPlaylist);

            if (userPlaylistDTO == null)
            {
                return userPlaylistDTO;
            }

            var musicList = await unitOfWork.MusicPlaylistRepository.GetAll(userPlaylistDTO.Id);

            userPlaylistDTO.MusicList = mapper.Map<IList<MusicViewDTO>>(musicList);

            return userPlaylistDTO;
        }
        public async Task<IEnumerable<PlaylistDTO>> GetPlaylistDTOListAsync(string UserId)
        {
            var userPlaylist = await unitOfWork.UserPlaylistRepository.GetByUserId(UserId);

            var userPlaylistDTO = mapper.Map<IEnumerable<PlaylistDTO>>(userPlaylist);

            foreach (var playlist in userPlaylistDTO)
            {
                var musicList = (await unitOfWork.MusicPlaylistRepository.GetAll(playlist.Id)).ToList();
                playlist.MusicList = mapper.Map<IList<MusicViewDTO>>(musicList);
            }

            return userPlaylistDTO;
        }
        public async Task UpdatePlaylistNameAsync(PlaylistDTO playlistDTO, string NewName)
        {
            var userPlaylist = mapper.Map<UserPlaylist>(playlistDTO);
            userPlaylist.PlaylistName = NewName;
            await unitOfWork.UserPlaylistRepository.Update(userPlaylist);
        }
    }
}