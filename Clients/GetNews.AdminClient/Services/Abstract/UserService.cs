using GetNews.AdminClient.Models.NewsModels;
using GetNews.AdminClient.Models.UserModels;
using GetNews.AdminClient.Services.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;

namespace GetNews.AdminClient.Services.Abstract
{
    public class UserService:IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateUser(UserVM user)
        {
            var response = await _httpClient.PostAsJsonAsync<UserVM>($"/api/users/SignUp/", user);
            return response.IsSuccessStatusCode;
        }
    }
}
