using GetNews.AdminClient.Models.UserModels;

namespace GetNews.AdminClient.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> CreateUser(UserVM user);
    }
}
