using BlazorUI.Models.AccountModels;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using BlazorUI.Services.Interfaces;

namespace BlazorUI.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        
        public AccountService(HttpClient client)
        {
            _httpClient = client;
        }

        public Task<UserViewModel> AuthenticateUserAsync(UserViewModel userParams)
        {
            throw new System.NotImplementedException();
        }

        public async Task<RegisterViewModel> RegisterUserAsync(RegisterViewModel user)
        {
            string serializedUser = JsonSerializer.Serialize(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Account/Registration");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            var responseStatusCode = response.StatusCode;

            using var responseBody = await response.Content.ReadAsStreamAsync();

            var returnedUser = await JsonSerializer.DeserializeAsync<RegisterViewModel>(responseBody);

            return await Task.FromResult(returnedUser);
        }
    }
}
