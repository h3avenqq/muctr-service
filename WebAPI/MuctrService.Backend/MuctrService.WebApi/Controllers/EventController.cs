using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Events.Queries.GetEventDetails;
using MuctrService.Application.SQRS.Events.Queries.GetEventList;
using System;
using System.Threading.Tasks;

namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EventController : BaseController
    {
        private readonly IMapper _mapper;

        public EventController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<EventDetailsVm>> Get(Guid id, int? limit, bool? unfinished)
        {
            if (id != Guid.Empty)
            {
                var query = new GetEventDetailsQuery
                {
                    Id = id
                };

                var vm = await Mediator.Send(query);

                return Ok(vm);
            }
            else if (limit!=null && unfinished != null)
            {
                var query = new GetEventListQuery
                {
                    Limit = (int)limit,
                    Unfinished = (bool)unfinished
                };

                var vm = await Mediator.Send(query);

                return Ok(vm);
            }

            return NotFound();
        }
    }
}
