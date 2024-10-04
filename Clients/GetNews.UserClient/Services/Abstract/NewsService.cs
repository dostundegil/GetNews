using GetNews.Shared.Dtos;
using GetNews.UserClient.Models.NewsModels;
using GetNews.UserClient.Services.Interfaces;

namespace GetNews.UserClient.Services.Abstract
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewsVM>> GetAll()
        {
            //[controller]/[action]/{code}

            var response = await _httpClient.GetAsync($"news");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadFromJsonAsync<Response<List<NewsVM>>>();
            return content.Data;
        }

        public async Task<NewsVM> GetById(string Id)
        {
            //[controller]/[action]/{code}

            var response = await _httpClient.GetAsync($"news/{Id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var content = await response.Content.ReadFromJsonAsync<Response<NewsVM>>();
            return content.Data;
        }

    }
}
