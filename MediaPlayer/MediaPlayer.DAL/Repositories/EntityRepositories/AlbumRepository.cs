using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(MediaDBContext db)
            : base(db)
        {
        }

        public async Task<Album> Get(string Name, string Author)
        {
            return await db.Set<Album>().FirstOrDefaultAsync(e => e.Name == Name && e.Author == Author);
        }

        public async Task<IEnumerable<Album>> GetAuthorAlbums(string Author)
        {
            return await db.Albums.Where(e => e.Author == Author).ToListAsync();
        }
    }
}
