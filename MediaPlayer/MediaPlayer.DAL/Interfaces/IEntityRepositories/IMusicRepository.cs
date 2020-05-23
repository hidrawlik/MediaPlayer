using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IMusicRepository : IGenericRepository<Music>
    {
        Task<IEnumerable<Music>> GetByName(string Name);
        Task<Music> Get(string Name, string Author, int? Year);
        Task<ICollection<Music>> GetByAlbumId(int AlbumId);
    }
}
