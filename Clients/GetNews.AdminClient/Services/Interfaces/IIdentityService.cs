using GetNews.AdminClient.Models.IdentityModels;
using GetNews.Shared.Dtos;
using IdentityModel.Client;

namespace GetNews.AdminClient.Services.Interfaces
{
    public interface IIdentityService
    {
        Task<Response<bool>> SignIn(SignInInput signInInput);

        Task<TokenResponse> GetAccessTokenByRefreshToken();

        Task RevokeRefreshToken();
    }
}
