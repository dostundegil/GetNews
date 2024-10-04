namespace GetNews.Services.NotificationServices.Services.Interfaces
{
    public interface ITokenService
    {
        public Task<string> GetTokenAsync();
    }
}
