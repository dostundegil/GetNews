using GetNews.AdminClient.Models.NewsModels;
using GetNews.AdminClient.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetNews.AdminClient.Controllers
{
    [Authorize]
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _newsService.GetAll();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateNewsVM createNews)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _newsService.Create(createNews);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var news = await _newsService.GetById(id);

            if (news == null)
            {
                RedirectToAction(nameof(Index));
            }

            UpdateNewsVM updateNews = new()
            {
                 Content =  news.Content,
                 Id = news.Id,
                 image_url = news.image_url,
                is_published = news.is_published,   
                 Summary = news.Summary,
                 Title = news.Title
            };

            return View(updateNews);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateNewsVM updateNews)
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(Index));
            }

            await _newsService.Update(updateNews);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(string id)
        {
            await _newsService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
