using GetNews.AdminClient.Models.NewsModels;

namespace GetNews.AdminClient.Services.Interfaces
{


    public interface INewsService
    {
        public Task<List<NewsVM>> GetAll();
        public Task<NewsVM> GetById(string Id);
        public Task<bool> Create(CreateNewsVM news);
        public Task<bool> Update(UpdateNewsVM news);
        public Task<bool> Delete(string Id);
    }
}
