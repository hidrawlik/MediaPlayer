using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;

namespace MediaPlayer.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMusicRepository MusicRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMusicGenreRepository MusicGenreRepository { get; }
        IAlbumRepository AlbumRepository { get; }
        IMusicPlaylistRepository MusicPlaylistRepository { get; }
        IUserPlaylistRepository UserPlaylistRepository { get; }
    }
}
