using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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
using AutoMapper;
using MediaPlayer.BLL;
using FluentValidation.AspNetCore;
using MediaPlayer.WEBAPI.Filters;
using Microsoft.OpenApi.Models;
using System;
using System.Xml.XPath;
using MediaPlayer.BLL.DTOs;

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

            services.AddAutoMapper(typeof(OrganizationProfile));

            #region FluentValidation

            services.AddMvc(setup =>
            {
                setup.Filters.Add(typeof(ValidatorActionFilter));
            }).AddFluentValidation();

            #region DTO Validators
            services.AddTransient<IValidator<MusicCUDTO>, MusicCUDTOValidator>();
            services.AddTransient<IValidator<GenreDTO>, GenreDTOValidator>();
            services.AddTransient<IValidator<AlbumDTO>, AlbumDTOValidator>();
            #endregion

            #endregion


            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MediaPlayer API",
                    Description = "ASP.NET Core Web API"
                });

                c.IncludeXmlComments(GetXmlCommentsPath());
            });
            #endregion
        }

        private string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\SwaggerTest.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                app.UseSwagger();

                app.UseSwaggerUI(c =>
                    {
                        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My MediaPlayer API V1");
                    });
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
