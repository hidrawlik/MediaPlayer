using MediaPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IGenreRepository : IGenericRepository<Genre>
    {
        Task<Genre> GetByName(string Name);
    }
}
