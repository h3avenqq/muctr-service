using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Faculties.Queries.GetFacultyList;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FacultyController : BaseController
    {
        private readonly IMapper _mapper;

        public FacultyController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<FacultyListVm>> GetAll()
        {
            var query = new GetFacultyListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

    }
}
