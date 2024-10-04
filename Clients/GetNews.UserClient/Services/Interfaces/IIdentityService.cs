using GetNews.Shared.Dtos;
using IdentityModel.Client;

namespace GetNews.UserClient.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<TokenResponse> GetAccessTokenByRefreshToken();
    }
}
