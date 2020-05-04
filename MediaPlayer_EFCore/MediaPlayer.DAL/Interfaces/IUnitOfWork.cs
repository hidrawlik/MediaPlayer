using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMusicPlaylistRepository musicPlaylistsRepository { get; }
        IMusicRepository musicRepository { get; }
        IUserPlaylistRepository userPlaylistsRepository { get; }
        IUserRepository usersRepository { get; }
    }
}
