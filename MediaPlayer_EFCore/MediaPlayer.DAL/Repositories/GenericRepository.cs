using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MediaPlayer.DAL.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly MediaDBContext db;

        public GenericRepository(MediaDBContext db)
        {
            this.db = db;
        }

        public async Task Add(TEntity entity)
        {
            await db.Set<TEntity>().AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            db.Set<TEntity>().Remove(entity);
            await db.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int Id)
        {
            return await db.Set<TEntity>().FirstOrDefaultAsync(t => t.Id == Id);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await db.Set<TEntity>().ToListAsync();
        }

        public async Task Update(TEntity entity)
        {
            db.Set<TEntity>().Update(entity);
            await db.SaveChangesAsync();
        }
    }
}
