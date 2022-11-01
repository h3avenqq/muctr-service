using Microsoft.AspNetCore.Mvc;

namespace MuctrSite.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetDepartment()
        {
            return View();
        }
    }
}
