using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MusicPlayer.DAL;
using MusicPlayer.DAL.EFCoreContexts;
using MusicPlayer.DAL.Interfaces;
using MusicPlayer.DAL.Interfaces.IEntityRepositories;
using MusicPlayer.DAL.Repositories.EntityRepositories;
using MusicPlayer.DAL.UnitOfWork;
using MusicPlayer.BLL.Services;
using MusicPlayer.BLL.Interfaces.IServices;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using FluentValidation;
using MusicPlayer.BLL.Validation;
using AutoMapper;
using MusicPlayer.BLL;
using FluentValidation.AspNetCore;
using Microsoft.OpenApi.Models;
using System;
using MusicPlayer.BLL.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace MusicPlayer.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicDBContext>(opts => opts.UseSqlServer(ConnectionString.Value));

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
            services.AddTransient<IAccountService, AccountService>(); // Identity
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IPlaylistService, PlaylistService>();
            #endregion

            services.AddAutoMapper(typeof(MapperProfile));

            #region DTO Validators
            services.AddTransient<IValidator<MusicCUDTO>, MusicCUDTOValidator>();
            services.AddTransient<IValidator<GenreDTO>, GenreDTOValidator>();
            services.AddTransient<IValidator<AlbumDTO>, AlbumDTOValidator>();
            services.AddTransient<IValidator<PlaylistDTO>, PlaylistDTOValidator>();
            services.AddTransient<IValidator<MusicPlaylistDTO>, MusicPlaylistDTOValidator>();
            services.AddTransient<IValidator<PlaylistCUDTO>, PlaylistCUDTOValidator>();

            // Identity
            services.AddTransient<IValidator<UserDTO>, UserDTOValidator>();
            services.AddTransient<IValidator<UserLoginDTO>, UserLoginDTOValidator>();
            services.AddTransient<IValidator<UserUpdateDTO>, UserUpdateDTOValidator>();
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
            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<MusicDBContext>();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 4;
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

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetSection("JWTConfiguration")["JwtIssuer"],

                        ValidateAudience = true,
                        ValidAudience = Configuration.GetSection("JWTConfiguration")["JwtAudience"],
                        ValidateLifetime = true,

                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JWTConfiguration")["JwtKey"])),
                        ValidateIssuerSigningKey = true,
                        ClockSkew = TimeSpan.Zero,
                    };
                });

            services.AddTransient<JWT>();
        }
       
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

        private string GetXmlCommentsPath()
        {
            return string.Format(@"{0}\SwaggerFile.XML", AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
