using Microsoft.AspNetCore.Mvc;
using MuctrSite.Models;
using System.Diagnostics;

namespace MuctrSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult GetAllNews()
        {
            return View();
        }
        public IActionResult GetAllActions()
        {
            return View();
        }

        public IActionResult GetNews()
        {
            return View();
        }
        public IActionResult GetActions()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}