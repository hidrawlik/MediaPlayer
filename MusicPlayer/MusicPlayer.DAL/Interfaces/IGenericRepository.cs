using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task Add(TEntity entity);

        Task<bool> Any(int Id);
        
        Task Delete(TEntity entity);

        Task<TEntity> Get(int Id);

        Task<IEnumerable<TEntity>> GetAll();

        Task Update(TEntity entity);
    }
}
