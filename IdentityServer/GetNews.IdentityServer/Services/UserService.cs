using GetNews.IdentityServer.Dtos;
using GetNews.IdentityServer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GetNews.IdentityServer.Services
{
    public class UserService:IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> CreateUser(UserSignUpDto signUp)
        {
            var user = new ApplicationUser
            {
                UserName = signUp.UserName,
                Email = signUp.Email,
            };
            var result = await _userManager.CreateAsync(user, signUp.Password);

            return result;
        }
    }
}
