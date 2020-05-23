using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MediaPlayer.DAL;
using MediaPlayer.DAL.EFCoreContexts;
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Interfaces.IEntityRepositories;
using MediaPlayer.DAL.Repositories.EntityRepositories;
using MediaPlayer.DAL.UnitOfWork;
using MediaPlayer.BLL.Services;
using MediaPlayer.BLL.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using MediaPlayer.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using MediaPlayer.BLL.DTOs.MusicDTO;
using MediaPlayer.BLL.Validation;

namespace MediaPlayer.WEBAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MediaDBContext>(opts => opts.UseSqlServer(MyConnection.Connection));
            
            services.AddControllers();

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MediaDBContext>();

            #region Repositories
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<IAlbumRepository, AlbumRepository>();
            services.AddTransient<IMusicGenreRepository, MusicGenreRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IMusicPlaylistRepository, MusicPlaylistRepository>();
            services.AddTransient<IUserPlaylistRepository, UserPlaylistRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #region Services
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IGenreService, GenreService>();
            #endregion

            #region DTO Validators
            services.AddTransient<IValidator<MusicCUDTO>, MusicCUDTOValidator>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
