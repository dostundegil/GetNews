using GetNews.Services.NotificationServices.Services.Interfaces;
using IdentityModel.Client;
using System.Net.Http;

namespace GetNews.Services.NotificationServices.Services.Abstractions
{
    public class TokenService:ITokenService
    {
        private readonly HttpClient _client;

        public TokenService(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("IdentityServerClient");
        }

        public async Task<string> GetTokenAsync()
        {
            var tokenResponse = await _client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "connect/token", // Relative path, because BaseAddress is already set
                ClientId = "mail_service_client",
                ClientSecret = "super_secret_password",
                Scope = "mail_service"
            });

            return tokenResponse.AccessToken;
        }
    }
}
