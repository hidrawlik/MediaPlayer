using System;
using System.Collections.Generic;
using System.Text;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;

namespace MediaPlayer.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IMusicRepository _musicRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IMusicGenreRepository _musicGenreRepository;
        private readonly IAlbumRepository _albumRepository;
        private readonly IMusicPlaylistRepository _musicPlaylistRepository;
        private readonly IUserPlaylistRepository _userPlaylistRepository;

        public UnitOfWork(IMusicRepository musicRepository,
            IGenreRepository genreRepository,
            IMusicGenreRepository musicGenreRepository,
            IAlbumRepository albumRepository,
            IMusicPlaylistRepository musicPlaylistRepository,
            IUserPlaylistRepository userPlaylistRepository)
        {
            _musicRepository = musicRepository;
            _genreRepository = genreRepository;
            _musicGenreRepository = musicGenreRepository;
            _albumRepository = albumRepository;
            _musicPlaylistRepository = musicPlaylistRepository;
            _userPlaylistRepository = userPlaylistRepository;
        }

        public IMusicRepository MusicRepository
        {
            get
            {
                return _musicRepository;
            }
        }
        public IGenreRepository GenreRepository
        {
            get
            {
                return _genreRepository;
            }
        }
        public IMusicGenreRepository MusicGenreRepository
        {
            get
            {
                return _musicGenreRepository;
            }
        }
        public IAlbumRepository AlbumRepository
        {
            get
            {
                return _albumRepository;
            }
        }
        public IMusicPlaylistRepository MusicPlaylistRepository
        {
            get
            {
                return _musicPlaylistRepository;
            }
        }
        public IUserPlaylistRepository UserPlaylistRepository
        {
            get
            {
                return _userPlaylistRepository;
            }
        }
    }
}
