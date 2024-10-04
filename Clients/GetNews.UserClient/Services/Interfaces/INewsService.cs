using GetNews.UserClient.Models.NewsModels;

namespace GetNews.UserClient.Services.Interfaces
{
    public interface INewsService
    {
        public Task<List<NewsVM>> GetAll();
        public Task<NewsVM> GetById(string Id);

    }
}
