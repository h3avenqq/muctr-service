using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TestController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            var json = System.IO.File.ReadAllText("Controllers/testJson.txt");

            var objects = JsonArray.Parse(json);

            return Ok(objects);
        }
    }
}
