using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;

namespace MediaPlayer.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMusicPlaylistRepository _musicPlaylistRepository;
        private readonly IMusicRepository _musicRepository;
        private readonly IUserPlaylistRepository _userPlaylistRepository;
        private readonly IUserRepository _userRepository;
        
        public UnitOfWork(IMusicPlaylistRepository musicPlaylistsRepository,
            IMusicRepository musicRepository,
            IUserPlaylistRepository userPlaylistsRepository,
            IUserRepository usersRepository)
        {
            _musicPlaylistRepository = musicPlaylistsRepository;
            _musicRepository = musicRepository;
            _userPlaylistRepository = userPlaylistsRepository;
            _userRepository = usersRepository;
        }

        public IMusicPlaylistRepository musicPlaylistsRepository
        {
            get
            {
                return _musicPlaylistRepository;
            }
        }
        
        public IMusicRepository musicRepository
        {
            get
            {
                return _musicRepository;
            }
        }
        
        public IUserPlaylistRepository userPlaylistsRepository
        {
            get
            {
                return _userPlaylistRepository;
            }
        }
        
        public IUserRepository usersRepository
        {
            get
            {
                return _userRepository;
            }
        }
    }
}
