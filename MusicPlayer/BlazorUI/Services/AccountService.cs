using BlazorUI.Models.AccountModels;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorUI.Services.Interfaces;
using System.Collections.Generic;
using BlazorUI.Pages;

namespace BlazorUI.Services
{
    public class AccountService : IAccountService
    {
        private readonly HttpClient _httpClient;
        
        public AccountService(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<List<string>> RegisterUserAsync(RegisterViewModel user)
        {
            string serializedUser = JsonSerializer.Serialize(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Account/Register");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            if(response.IsSuccessStatusCode)
            {
                return null;
            }

            using var responseBody = await response.Content.ReadAsStreamAsync();

            var errorList = await JsonSerializer.DeserializeAsync<List<string>>(responseBody);

            return errorList;
        }

        public async Task<UserViewModel> AuthenticateUserAsync(UserLoginModel user)
        {
            string serializedUser = JsonSerializer.Serialize(user);

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "Account/Authenticate");
            requestMessage.Content = new StringContent(serializedUser);

            requestMessage.Content.Headers.ContentType
                = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(requestMessage);

            response.EnsureSuccessStatusCode();

            using var responseBody = await response.Content.ReadAsStreamAsync();

            var returnedUser = await JsonSerializer.DeserializeAsync<UserViewModel>(responseBody);

            return returnedUser;
        }
    }
}
