namespace GetNews.UserClient.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        public Task<string> GetToken();
    }
}
