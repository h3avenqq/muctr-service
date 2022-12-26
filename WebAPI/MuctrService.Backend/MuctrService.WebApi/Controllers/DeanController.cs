using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Deans.Queries.GetDeanDetails;
using System;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DeanController : BaseController
    {

        [HttpGet("{facultyId}")]
        public async Task<ActionResult<DeanDetailsVm>> Get(Guid facultyId)
        {
            var query = new GetDeanDetailsQuery
            {
                FacultyId = facultyId
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
