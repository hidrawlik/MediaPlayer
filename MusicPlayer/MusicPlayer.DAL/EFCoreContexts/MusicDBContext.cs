using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MusicPlayer.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace MusicPlayer.DAL.EFCoreContexts
{
    public partial class MusicDBContext : IdentityDbContext<User>
    {
        public MusicDBContext() { }

        public MusicDBContext(DbContextOptions<MusicDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<UserPlaylist> UserPlaylists { get; set; }
        public virtual DbSet<MusicPlaylist> MusicPlaylists { get; set; }
        public virtual DbSet<Music> Music { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MusicGenre> MusicGenres { get; set; }
        public virtual DbSet<Album> Albums { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(MyConnection.Connection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<UserPlaylist>(entity =>
            {
                entity.HasIndex(e => new { e.UserId, e.PlaylistName })
                    .HasName("UIX_UserPlaylists")
                    .IsUnique();

                entity.Property(e => e.PlaylistName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserPlaylists)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_UserPlaylists_Users");
            });

            modelBuilder.Entity<MusicPlaylist>(entity =>
            {
                entity.HasIndex(e => new { e.UserPlaylistId, e.MusicId })
                    .HasName("UIX_PlaylistMusic")
                    .IsUnique();

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.MusicPlaylists)
                    .HasForeignKey(d => d.MusicId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MusicPlaylists_Music");

                entity.HasOne(d => d.UserPlaylist)
                    .WithMany(p => p.MusicPlaylists)
                    .HasForeignKey(d => d.UserPlaylistId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_MusicPlaylists_UserPlaylists");
            });

            modelBuilder.Entity<Music>(entity =>
            {
                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasIndex(e => new { e.Name, e.Author, e.Year })
                    .IsUnique()
                    .HasName("UIX_Music_Name_Author_Year");

                entity.HasOne(m => m.Album)
                    .WithMany(a => a.Musics)
                    .HasForeignKey(m => m.AlbumId)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<Genre>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique()
                    .HasName("UIX_GenreName");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<MusicGenre>(entity =>
            {
                entity.HasIndex(e => new { e.MusicId, e.GenreId })
                    .IsUnique()
                    .HasName("UIX_MusicGenreTable_MusicId_GenreId");

                entity.HasOne(mg => mg.Genre)
                    .WithMany(g => g.MusicGenres)
                    .HasForeignKey(mg => mg.GenreId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(mg => mg.Music)
                    .WithMany(m => m.MusicGenres)
                    .HasForeignKey(mg => mg.MusicId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Album>(entity =>
            {
                entity.HasIndex(e => new { e.Name, e.Author })
                    .IsUnique()
                    .HasName("UIX_AlbumTable_Name_Author");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Author)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Year)
                   .IsRequired();
            });

            modelBuilder.Entity<Genre>().HasData(
               new Genre[] {
                    new Genre { Id = 1, Name = "Поп-музика" },
                    new Genre { Id = 2, Name = "Рок" },
                    new Genre { Id = 3, Name = "Фанк"}
               });

            modelBuilder.Entity<Album>().HasData(
                new Album[] {
                    new Album { Id = 1, Name = "Голий король", Author = "Бумбокс", Year = 2017 },
                    new Album { Id = 2, Name = "Музасфера", Author = "Сергій Бабкін", Year = 2018 },
                    new Album { Id = 3, Name = "Один в каное", Author = "Один в каное", Year = 2016 },
                    new Album { Id = 4, Name = "III", Author = "Бумбокс", Year = 2008 }
                });

            modelBuilder.Entity<Music>().HasData(
                new Music[]
                {
                    new Music { Id = 1, Name = "Де би я", Author = "Сергій Бабкін", AlbumId = 2, Year = 2018 },
                    new Music { Id = 2, Name = "Квіти у волоссі", Author = "Бумбокс", Year = 2006 },
                    new Music { Id = 3, Name = "Ми вільні", Author = "Letay", Year = 2020 },
                    new Music { Id = 4, Name = "Наодинці", Author = "Бумбокс", AlbumId = 4, Year = 2006 },
                    new Music { Id = 5, Name = "8-Ий колір", Author = "Мотор'Ролла", Year = 2005 },
                    new Music { Id = 6, Name = "Човен", Author = "Один в каное", AlbumId = 3, Year = 2016 },
                    new Music { Id = 7, Name = "Сталеві квіти", Author = "Бумбокс", AlbumId = 1, Year = 2017 },
                    new Music { Id = 8, Name = "Мила моя", Author = "Letay", Year = 2018 },
                    new Music { Id = 9, Name = "Пообіцяй мені", Author = "Один в каное", AlbumId = 3, Year = 2016 },
                    new Music { Id = 10, Name = "Дихай повільно", Author = "Сергій Бабкін", Year = 2018 }
                });

            modelBuilder.Entity<MusicGenre>().HasData(
                new MusicGenre[] {
                    new MusicGenre { Id = 1, MusicId = 1, GenreId = 1 },
                    new MusicGenre { Id = 2, MusicId = 2, GenreId = 1 },
                    new MusicGenre { Id = 3, MusicId = 3, GenreId = 1 },
                    new MusicGenre { Id = 4, MusicId = 4, GenreId = 1 },
                    new MusicGenre { Id = 5, MusicId = 5, GenreId = 1 },
                    new MusicGenre { Id = 6, MusicId = 6, GenreId = 1 },
                    new MusicGenre { Id = 7, MusicId = 7, GenreId = 1 },
                    new MusicGenre { Id = 8, MusicId = 8, GenreId = 1 },
                    new MusicGenre { Id = 9, MusicId = 9, GenreId = 1 },
                    new MusicGenre { Id = 10, MusicId = 10, GenreId = 1 }
                });

            modelBuilder.Entity<User>().HasData(
                new User[] {
                    new User { UserName = "Carendoh", NormalizedUserName = "CARENDOH", FirstName = "Oleksandr", LastName = "Slobodian", Email = "test@gmail.com", NormalizedEmail = "TEST@GMAIL.COM"}
                });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
