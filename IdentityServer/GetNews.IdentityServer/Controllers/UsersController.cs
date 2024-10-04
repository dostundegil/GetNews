using GetNews.IdentityServer.Dtos;
using GetNews.IdentityServer.Models;
using GetNews.IdentityServer.Services;
using GetNews.IdentityServer.Services.RabbitMQ;
using GetNews.Shared.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace GetNews.IdentityServer.Controllers
{
    [Authorize(LocalApi.PolicyName)]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserService _userService;
        private readonly IRabbitMqService _rabbitMqService;

        public UsersController(UserManager<ApplicationUser> userManager, IUserService userService, IRabbitMqService rabbitMqService)
        {
            _userManager = userManager;
            _userService = userService;
            _rabbitMqService = rabbitMqService;
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpDto signUp)
        {
            var result = await _userService.CreateUser(signUp);

            if (!result.Succeeded)
                return BadRequest(Response<NoContent>.Fail(result.Errors.Select(x => x.Description).ToList(), 400));

            _rabbitMqService.SendEmailMessage(new SendEmailModel() { Email = signUp.Email });

            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var userIdClaim = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);

            if (userIdClaim == null) return BadRequest();

            var user = await _userManager.FindByIdAsync(userIdClaim.Value);

            if (user == null) return BadRequest();

            return Ok(new GetUserDto { userId = user.Id, UserName = user.UserName, Email = user.Email });
        }
    }
}
