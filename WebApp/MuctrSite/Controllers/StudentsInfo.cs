using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MuctrSite.Controllers
{
    public class StudentsInfo : Controller
    {
        public IActionResult Index(int index = 0)
        {
            return View(index);
        }
    }
}
