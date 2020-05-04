﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediaPlayer.BLL.Interfaces;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL;

namespace MediaPlayer.BLL.Services
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