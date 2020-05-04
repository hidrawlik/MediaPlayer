using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL;

namespace MediaPlayer.BLL.Services
{
    public class MusicPlaylistsService : IMusicPlaylistsService
    {
        private IUnitOfWork unitOfWork;

        public MusicPlaylistsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(MusicPlaylists playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Add(playlist);
        }

        public async Task Delete(MusicPlaylists playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Delete(playlist);
        }

        public async Task<MusicPlaylists> Get(int Id)
        {
            return await unitOfWork.musicPlaylistsRepository.Get(Id);
        }

        public async Task<IEnumerable<MusicPlaylists>> GetAll()
        {
            return await unitOfWork.musicPlaylistsRepository.GetAll();
        }

        public async Task Update(MusicPlaylists playlist)
        {
            await unitOfWork.musicPlaylistsRepository.Update(playlist);
        }
    }
}
