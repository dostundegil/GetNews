using GetNews.AdminClient.Models;
using GetNews.AdminClient.Models.UserModels;
using GetNews.AdminClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GetNews.AdminClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public  async Task<IActionResult> Index()
        {
            UserVM vm = new();
           await _userService.CreateUser(vm);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
