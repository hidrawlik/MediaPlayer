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
                entity.Property(e => e.Album).HasMaxLength(50);

                entity.Property(e => e.GroupName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
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
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.NickName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Status).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
