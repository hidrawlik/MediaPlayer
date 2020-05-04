using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Services
{
    public class UserPlaylistService : IUserPlaylistService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserPlaylistService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(UserPlaylist userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Add(userPlaylist);
        }

        public async Task Delete(UserPlaylist userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Delete(userPlaylist);
        }

        public async Task<UserPlaylist> Get(int Id)
        {
            return await unitOfWork.userPlaylistsRepository.Get(Id);
        }

        public async Task<IEnumerable<UserPlaylist>> GetAll()
        {
            return await unitOfWork.userPlaylistsRepository.GetAll();
        }

        public async Task Update(UserPlaylist userPlaylist)
        {
            await unitOfWork.userPlaylistsRepository.Update(userPlaylist);
        }
    }
}
