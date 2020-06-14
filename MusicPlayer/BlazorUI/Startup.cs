using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BlazorUI.Services;
using System.Net.Http;
using BlazorUI.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;

namespace BlazorUI
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
            services.AddTransient(client =>
            new HttpClient
            {
                BaseAddress = new Uri(Configuration.GetSection("AppSettings")["API_Address"])
            });

            services.AddRazorPages();
            services.AddServerSideBlazor();

            #region Services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IAlbumService, AlbumService>();
            services.AddScoped<MusicService>();
            services.AddScoped<PlaylistService>();
            #endregion

            services.AddScoped<AuthenticationStateProvider, ServerAuthenticationStateProvider>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
