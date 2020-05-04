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
using MediaPlayer.DAL.Interfaces;
using MediaPlayer.DAL.Repositories;
using MediaPlayer.DAL.UnitOfWork;
using MediaPlayer.BLL.Services;
using MediaPlayer.BLL.Interfaces;
using Microsoft.EntityFrameworkCore;

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

            #region Repositories
            services.AddTransient<IMusicPlaylistsRepository, MusicPlaylistsRepository>();
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<IUserPlaylistsRepository, UserPlaylistsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();
            #endregion

            #region Services
            services.AddTransient<IMusicPlaylistsService, MusicPlaylistsService>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IUserPlaylistsService, UserPlaylistsService>();
            services.AddTransient<IUsersService, UsersService>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();
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
