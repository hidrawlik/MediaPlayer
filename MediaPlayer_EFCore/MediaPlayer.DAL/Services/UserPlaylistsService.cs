using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Services
{
    public class UserPlaylistsService : IUserPlaylistsService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserPlaylistsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(UserPlaylists userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Add(userPlaylist);
        }

        public async Task Delete(UserPlaylists userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Delete(userPlaylist);
        }

        public async Task<UserPlaylists> Get(int Id)
        {
            return await unitOfWork.userPlaylistsRepository.Get(Id);
        }

        public async Task<IEnumerable<UserPlaylists>> GetAll()
        {
            return await unitOfWork.userPlaylistsRepository.GetAll();
        }

        public async Task Update(UserPlaylists userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Update(userPlaylist);
        }
    }
}
