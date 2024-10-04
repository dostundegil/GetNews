namespace GetNews.AdminClient.Services.Interfaces
{
    public interface IClientCredentialTokenService
    {
        public Task<string> GetToken();
    }
}
