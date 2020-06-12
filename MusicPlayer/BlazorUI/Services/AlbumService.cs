using BlazorUI.Models;
using BlazorUI.Services.Interfaces;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorUI.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly HttpClient _httpClient;

        public AlbumService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<AlbumViewModel>> GetAlbumsAsync()
        {
            var response = await _httpClient.GetAsync("album");
            response.EnsureSuccessStatusCode();

            using var responseContent = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<AlbumViewModel>>(responseContent);
        }
    }
}
