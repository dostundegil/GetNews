using GetNews.UserClient.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GetNews.UserClient.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            var news = await _newsService.GetAll();
            return View(news);
        }
    }
}
