using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Schedules.Queries.GetScheduleList;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ScheduleController : BaseController
    {
        private readonly IMapper _mapper;

        public ScheduleController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ScheduleListVm>> GetAll()
        {
            var scheduleQuery = new GetScheduleListQuery();

            var vm = await Mediator.Send(scheduleQuery);

            return Ok(vm);
        }
    }
}
