using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetByName(string Name);
    }
}
