using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using MediaPlayer.DAL.Entities;

namespace MediaPlayer.DAL.EFCoreContexts
{
    public partial class MediaDBContext : DbContext
    {
        public MediaDBContext()
        {
        }

        public MediaDBContext(DbContextOptions<MediaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Music> Music { get; set; }
        public virtual DbSet<MusicPlaylist> MusicPlaylists { get; set; }
        public virtual DbSet<UserPlaylist> UserPlaylists { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Admin> Admins { get; set; }
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
                    .HasForeignKey(m => m.AlbumId);
            });

            modelBuilder.Entity<MusicPlaylist>(entity =>
            {
                entity.HasIndex(e => new { e.UserPlaylistId, e.MusicId })
                    .HasName("UIX_PlaylistMusic")
                    .IsUnique();

                entity.HasOne(d => d.Music)
                    .WithMany(p => p.MusicPlaylists)
                    .HasForeignKey(d => d.MusicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MusicPlaylists_Music");

                entity.HasOne(d => d.UserPlaylist)
                    .WithMany(p => p.MusicPlaylists)
                    .HasForeignKey(d => d.UserPlaylistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MusicPlaylists_UserPlaylists");
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
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserPlaylists_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Nickname).HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.HasIndex(e => e.Email)
                    .HasName("UIX_UserEmail")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("UserId");

                entity.HasOne(e => e.User)
                    .WithOne(e => e.Admin)
                    .HasForeignKey<Admin>(e => e.Id);
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
                    .HasForeignKey(mg => mg.GenreId);

                entity.HasOne(mg => mg.Music)
                    .WithMany(m => m.MusicGenres)
                    .HasForeignKey(mg => mg.MusicId);
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

            modelBuilder.Entity<Music>().HasData(
                new Music[]
                {
                    new Music { Id = 1, Name = "Вітер без пилу", Author = "Letay", Year = 2016 },
                    new Music { Id = 2, Name = "Квіти у волоссі", Author = "Бумбокс", Year = 2006 },
                    new Music { Id = 3, Name = "Пообіцяй мені", Author = "Один в каное", Year = 2016 },
                    new Music { Id = 4, Name = "Наодинці", Author = "Бумбокс", Year = 2006 },
                    new Music { Id = 5, Name = "8-Ий колір", Author = "Мотор'Ролла", Year = 2005 },
                    new Music { Id = 6, Name = "Човен", Author = "Один в каное", Year = 2016 },
                    new Music { Id = 7, Name = "Сталеві квіти", Author = "Бумбокс", Year = 2017 },
                });

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Nickname = "Carendoh",
                    FirstName = "Alex",
                    LastName = "Slobodian",
                    Email = "testemail@gmail.com",
                    Password = "0000",
                    DateOfBirth = new DateTime(2001, 04, 11)
                });

            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 1,
                    StatusCode = 0
                });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
