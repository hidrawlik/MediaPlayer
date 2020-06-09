using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.DAL.Configuration
{
    public class AlbumConfiguration : IEntityTypeConfiguration<Album>
    {
        public void Configure(EntityTypeBuilder<Album> builder)
        {
            builder.HasData(
                new Album[] {
                    new Album { Id = 1, Name = "Голий король", Author = "Бумбокс", Year = 2017 },
                    new Album { Id = 2, Name = "Музасфера", Author = "Сергій Бабкін", Year = 2018 },
                    new Album { Id = 3, Name = "Один в каное", Author = "Один в каное", Year = 2016 },
                    new Album { Id = 4, Name = "III", Author = "Бумбокс", Year = 2008 }
                });
        }
    }
}
