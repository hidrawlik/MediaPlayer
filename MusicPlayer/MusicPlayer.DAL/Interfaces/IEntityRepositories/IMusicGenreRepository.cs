using MediaPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IMusicGenreRepository : IGenericRepository<MusicGenre>
    {
        Task<ICollection<MusicGenre>> GetByMusicId(int MusicId);
    }
}
