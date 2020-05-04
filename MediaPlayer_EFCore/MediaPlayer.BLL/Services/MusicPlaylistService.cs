using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Services
{
    public class MusicPlaylistService : IMusicPlaylistService
    {
        private IUnitOfWork unitOfWork;

        public MusicPlaylistService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(MusicPlaylist playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Add(playlist);
        }

        public async Task Delete(MusicPlaylist playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Delete(playlist);
        }

        public async Task<MusicPlaylist> Get(int Id)
        {
            return await unitOfWork.musicPlaylistsRepository.Get(Id);
        }

        public async Task<IEnumerable<MusicPlaylist>> GetAll()
        {
            return await unitOfWork.musicPlaylistsRepository.GetAll();
        }

        public async Task Update(MusicPlaylist playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Update(playlist);
        }
    }
}
