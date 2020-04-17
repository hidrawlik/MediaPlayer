using System;
using System.Collections.Generic;
using System.Text;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMusicPlaylistsRepository musicPlaylistsRepository { get; }
        IMusicRepository musicRepository { get; }
        IUserPlaylistsRepository userPlaylistsRepository { get; }
        IUsersRepository usersRepository { get; }
    }
}
