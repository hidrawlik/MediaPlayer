using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MediaDBContext db)
            : base(db)
        {
        }

        public async Task<Genre> GetByName(string Name)
        {
            return await db.Set<Genre>().FirstOrDefaultAsync(e => e.Name == Name);
        }
    }
}
