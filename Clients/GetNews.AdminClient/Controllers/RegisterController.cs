using GetNews.AdminClient.Models.UserModels;
using GetNews.AdminClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetNews.AdminClient.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserVM user)
        {
            var response = _userService.CreateUser(user);
            return RedirectToAction("Index", "Home");
        }
    }
}
