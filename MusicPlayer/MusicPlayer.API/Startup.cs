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
using Microsoft.OpenApi.Models;
using System;
using MediaPlayer.BLL.DTOs;
using MediaPlayer.BLL.DTOs.UserDTO;

namespace MusicPlayer.API
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
            services.AddDbContext<MusicDBContext>(opts => opts.UseSqlServer(MyConnection.Connection));

            services.AddControllers().AddFluentValidation();

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

            // Identity
            services.AddTransient<IUserService, UserService>();
            #endregion

            services.AddAutoMapper(typeof(OrganizationProfile));

            #region DTO Validators
            services.AddTransient<IValidator<MusicCUDTO>, MusicCUDTOValidator>();
            services.AddTransient<IValidator<GenreDTO>, GenreDTOValidator>();
            services.AddTransient<IValidator<AlbumDTO>, AlbumDTOValidator>();

            // Identity
            services.AddTransient<IValidator<UserCreateDTO>, UserCreateDTOValidator>();
            services.AddTransient<IValidator<UserUpdateDTO>, UserEditDTOValidator>();
            #endregion

            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "MusicPlayer API",
                    Description = "ASP.NET Core Web API"
                });

                c.IncludeXmlComments(GetXmlCommentsPath());
            });
            #endregion

            #region Identity
            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<MusicDBContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Email settings.
                options.User.RequireUniqueEmail = true;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = "/Identity/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });
            #endregion
        }

        private string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\SwaggerFile.XML", AppDomain.CurrentDomain.BaseDirectory);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My MusicPlayer API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
