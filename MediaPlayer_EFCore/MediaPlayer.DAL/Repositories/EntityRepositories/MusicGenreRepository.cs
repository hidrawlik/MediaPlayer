using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Entities;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Repositories.EntityRepositories
{
    public class MusicGenreRepository : GenericRepository<MusicGenre>, IMusicGenreRepository
    {
        public MusicGenreRepository(MediaDBContext db)
            : base(db)
        {
        }
    }
}
