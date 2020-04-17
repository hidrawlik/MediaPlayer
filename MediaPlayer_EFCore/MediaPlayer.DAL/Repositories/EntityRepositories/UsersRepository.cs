using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Repositories
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository
    {
        public UsersRepository(MediaDBContext db)
            : base(db)
        {
        }
    }
}
