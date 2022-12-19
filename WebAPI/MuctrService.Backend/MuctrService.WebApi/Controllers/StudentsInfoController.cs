using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentsInfoList;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class StudentsInfoController : BaseController
    {
        private readonly IMapper _mapper;

        public StudentsInfoController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<StudentsInfoVm>> GetAll()
        {
            var studentsInfoQuery = new GetStudentsInfoQuery();

            var vm = await Mediator.Send(studentsInfoQuery);

            return Ok(vm);
        }
    }
}
