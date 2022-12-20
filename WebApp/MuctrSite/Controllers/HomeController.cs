using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;
using System.Diagnostics;
using System.Net.Http.Json;

namespace MuctrSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        static HttpClient httpClient = new HttpClient();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            NewsAndEvents _db = new NewsAndEvents();
            _db.Events = await httpClient.GetFromJsonAsync<EventsList>("https://localhost:7035/api/event?limit=3&unfinished=false");
            _db.News = await httpClient.GetFromJsonAsync<NewsList>("https://localhost:7035/api/news?limit=3");
            return View(_db);
        }

        public async Task<IActionResult> GetAllNews()
        {
            NewsList _db = await httpClient.GetFromJsonAsync<NewsList>("https://localhost:7035/api/news?limit=10");
            return View(_db);
        }
        public async Task<IActionResult> GetAllActions()
        {
            EventsList _db = await httpClient.GetFromJsonAsync<EventsList>("https://localhost:7035/api/event?limit=10&unfinished=false");
            return View(_db);
        }

        
        public async Task<IActionResult> GetNews(Guid? id)
        {
            News _db = await httpClient.GetFromJsonAsync<News>($"https://localhost:7035/api/news/{id}");
            return View(_db);
        }
        public async Task<IActionResult> GetActions(Guid? id)
        {
            Events _db = await httpClient.GetFromJsonAsync<Events>($"https://localhost:7035/api/event/{id}");
            return View(_db);
        }

        public async Task<IActionResult> DeleteNews(Guid? id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(
               $"https://localhost:7035/api/news/{id}");
            return RedirectToAction("GetAllNews", "Home");
        }

        public async Task<IActionResult> DeleteAction(Guid? id)
        {
            HttpResponseMessage response = await httpClient.DeleteAsync(
               $"https://localhost:7035/api/event/{id}");
            return RedirectToAction("GetAllActions", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}