using System;
using System.Collections.Generic;
using System.Text;
using MusicPlayer.DAL.Entities;
using MusicPlayer.DAL.Interfaces.IEntityRepositories;
using Microsoft.AspNetCore.Identity;

namespace MusicPlayer.DAL.Interfaces
{
    public interface IUnitOfWork
    {
        IMusicRepository MusicRepository { get; }
        IGenreRepository GenreRepository { get; }
        IMusicGenreRepository MusicGenreRepository { get; }
        IAlbumRepository AlbumRepository { get; }
        IMusicPlaylistRepository MusicPlaylistRepository { get; }
        IUserPlaylistRepository UserPlaylistRepository { get; }

        public UserManager<User> UserManager { get; }
        public SignInManager<User> SignInManager { get; }        
        public RoleManager<IdentityRole> RoleManager { get; }
    }
}
