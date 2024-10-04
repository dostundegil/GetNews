using GetNews.IdentityServer.Dtos;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace GetNews.IdentityServer.Services
{
    public interface IUserService
    {
        public Task<IdentityResult> CreateUser(UserSignUpDto signUp);
    }
}
