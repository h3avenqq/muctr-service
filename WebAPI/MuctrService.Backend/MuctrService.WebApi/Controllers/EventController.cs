using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.Events.Commands.CreateEvent;
using MuctrService.Application.SQRS.Events.Commands.DeleteEvent;
using MuctrService.Application.SQRS.Events.Commands.UpdateEvent;
using MuctrService.Application.SQRS.Events.Queries.GetEventDetails;
using MuctrService.Application.SQRS.Events.Queries.GetEventList;
using MuctrService.WebApi.Models.Event;
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
        public async Task<ActionResult<EventListVm>> GetAll(int limit, bool unfinished)
        {
            var query = new GetEventListQuery
            {
                Limit = (int)limit,
                Unfinished = (bool)unfinished
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EventDetailsVm>> Get(Guid id)
        {
            var query = new GetEventDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateEventDto createEventDto)
        {
            var command = _mapper.Map<CreateEventCommand>(createEventDto);

            var eventId = await Mediator.Send(command);

            return Ok(eventId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateEventDto updateEventDto)
        {
            var command = _mapper.Map<UpdateEventCommand>(updateEventDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteEventCommand 
            { 
                Id = id 
            };

            await Mediator.Send(command);

            return NoContent();
        }
    }
}
