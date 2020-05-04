using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Interfaces.IServices
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> Get(int Id);

        Task Add(User user);

        Task Update(User user);
        
        Task Delete(User user);
    }
}
