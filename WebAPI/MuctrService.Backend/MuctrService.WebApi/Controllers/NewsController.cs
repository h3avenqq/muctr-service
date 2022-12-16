using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.News.Commands.DeleteNews;
using MuctrService.Application.SQRS.News.Queries.GetNewsDetails;
using MuctrService.Application.SQRS.News.Queries.GetNewsList;
using System;
using System.Threading.Tasks;


namespace MuctrService.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;

        public NewsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<NewsListVm>> GetAll(int limit)
        {
            var query = new GetNewsListQuery
            {
                Limit = (int)limit
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id)
        {
            var query = new GetNewsDetailsQuery
            {
                Id = id
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteNewsCommand
            {
                Id = id
            };

            await Mediator.Send(command);

            return NoContent();
        }

    }
}
