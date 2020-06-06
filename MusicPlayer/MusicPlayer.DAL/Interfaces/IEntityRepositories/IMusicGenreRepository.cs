using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IMusicGenreRepository : IGenericRepository<MusicGenre>
    {
        Task<ICollection<MusicGenre>> GetByMusicId(int MusicId);
    }
}
