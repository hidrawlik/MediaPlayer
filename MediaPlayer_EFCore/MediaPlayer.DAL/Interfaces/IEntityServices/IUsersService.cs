﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<Users>> GetAll();

        Task<Users> Get(int Id);

        Task Add(Users user);

        Task Update(Users user);
        
        Task Delete(Users user);
    }
}
