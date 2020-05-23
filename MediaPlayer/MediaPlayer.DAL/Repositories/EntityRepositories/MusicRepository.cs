using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class MusicRepository : GenericRepository<Music>, IMusicRepository
    {
        public MusicRepository(MediaDBContext db)
            : base(db)
        {
        }

        public async Task<Music> Get(string Name, string Author, int? Year)
        {
            return await db.Set<Music>()
                .Where(e => e.Name.Equals(Name) && e.Author.Equals(Author) && e.Year.Equals(Year))
                .FirstOrDefaultAsync();
        }

        public async Task<ICollection<Music>> GetByAlbumId(int AlbumId)
        {
            return await db.Set<Music>().Where(e => e.AlbumId == AlbumId).ToListAsync();
        }

        public async Task<IEnumerable<Music>> GetByName(string Name)
        {
            return await db.Set<Music>()
                .Where(e => e.Name == Name)
                .ToListAsync();
        }
    }
}
