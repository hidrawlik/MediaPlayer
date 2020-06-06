using MusicPlayer.DAL.EFCoreContexts;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer.DAL.Repositories.EntityRepositories
{
    public class GenreRepository : GenericRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MusicDBContext db)
            : base(db)
        {
        }

        public async Task<Genre> GetByName(string Name)
        {
            return await db.Set<Genre>().FirstOrDefaultAsync(e => e.Name == Name);
        }
    }
}
