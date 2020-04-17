using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;

namespace MediaPlayer.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMusicPlaylistsRepository _musicPlaylistsRepository;
        private readonly IMusicRepository _musicRepository;
        private readonly IUserPlaylistsRepository _userPlaylistsRepository;
        private readonly IUsersRepository _usersRepository;
        
        public UnitOfWork(IMusicPlaylistsRepository musicPlaylistsRepository,
            IMusicRepository musicRepository,
            IUserPlaylistsRepository userPlaylistsRepository,
            IUsersRepository usersRepository)
        {
            _musicPlaylistsRepository = musicPlaylistsRepository;
            _musicRepository = musicRepository;
            _userPlaylistsRepository = userPlaylistsRepository;
            _usersRepository = usersRepository;
        }

        public IMusicPlaylistsRepository musicPlaylistsRepository
        {
            get
            {
                return _musicPlaylistsRepository;
            }
        }
        
        public IMusicRepository musicRepository
        {
            get
            {
                return _musicRepository;
            }
        }
        
        public IUserPlaylistsRepository userPlaylistsRepository
        {
            get
            {
                return _userPlaylistsRepository;
            }
        }
        
        public IUsersRepository usersRepository
        {
            get
            {
                return _usersRepository;
            }
        }
    }
}
