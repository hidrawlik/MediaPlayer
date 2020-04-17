using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Services
{
    public class MusicService : IMusicService
    {
        private IUnitOfWork unitOfWork;

        public MusicService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(Music music)
        {
            await unitOfWork.musicRepository.Add(music);
        }

        public async Task Delete(Music music)
        {
            await unitOfWork.musicRepository.Delete(music);
        }

        public async  Task<Music> Get(int Id)
        {
            return await unitOfWork.musicRepository.Get(Id);
        }

        public async Task<IEnumerable<Music>> GetAll()
        {
            return await unitOfWork.musicRepository.GetAll();
        }

        public async Task Update(Music music)
        {
            await unitOfWork.musicRepository.Update(music);
        }
    }
}
