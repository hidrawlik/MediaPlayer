using MediaPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces.IEntityRepositories
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<Album> Get(string Name, string Author);

        Task<IEnumerable<Album>> GetAuthorAlbums(string Author);
    }
}
