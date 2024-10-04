using GetNews.AdminClient.Models.ApiSettings;
using GetNews.AdminClient.Models.NewsModels;
using GetNews.AdminClient.Services.Interfaces;
using GetNews.Shared.Dtos;
using System.Net.Http.Json;

namespace GetNews.AdminClient.Services.Abstract
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

            var content =await response.Content.ReadFromJsonAsync<Response<List<NewsVM>>>();
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

        public async Task<bool> Create(CreateNewsVM news)
        {
            //[controller]/[action]/{code}

            var response = await _httpClient.PostAsJsonAsync<CreateNewsVM>($"news", news);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Update(UpdateNewsVM news)
        { 
            //[controller]/[action]/{code}

            var response = await _httpClient.PutAsJsonAsync<UpdateNewsVM>($"news", news);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(string Id)
        { 
            //[controller]/[action]/{code}

            var response = await _httpClient.DeleteAsync($"news/{Id}");
            return response.IsSuccessStatusCode;
        }
    }
}
