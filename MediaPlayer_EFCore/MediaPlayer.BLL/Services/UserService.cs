using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces.IServices;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(User user)
        {
            await unitOfWork.usersRepository.Add(user);
        }

        public async Task Delete(User user)
        {
            await unitOfWork.usersRepository.Delete(user);
        }

        public async Task<User> Get(int Id)
        {
            return await unitOfWork.usersRepository.Get(Id);
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await unitOfWork.usersRepository.GetAll();
        }

        public async Task Update(User user)
        {
            await unitOfWork.usersRepository.Update(user);
        }
    }
}
