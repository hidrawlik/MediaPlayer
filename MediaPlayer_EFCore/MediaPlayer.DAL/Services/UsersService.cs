using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUnitOfWork unitOfWork;

        public UsersService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task Add(Users user)
        {
            await unitOfWork.usersRepository.Add(user);
        }

        public async Task Delete(Users user)
        {
            await unitOfWork.usersRepository.Delete(user);
        }

        public async Task<Users> Get(int Id)
        {
            return await unitOfWork.usersRepository.Get(Id);
        }

        public async Task<IEnumerable<Users>> GetAll()
        {
            return await unitOfWork.usersRepository.GetAll();
        }

        public async Task Update(Users user)
        {
            await unitOfWork.usersRepository.Update(user);
        }
    }
}
