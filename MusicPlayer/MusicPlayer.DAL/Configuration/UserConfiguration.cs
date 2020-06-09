using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayer.DAL.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
               new User[] {
                    new User { UserName = "Carendoh", NormalizedUserName = "CARENDOH", FirstName = "Oleksandr", LastName = "Slobodian", Email = "test@gmail.com", NormalizedEmail = "TEST@GMAIL.COM"}
               });
        }
    }
}
