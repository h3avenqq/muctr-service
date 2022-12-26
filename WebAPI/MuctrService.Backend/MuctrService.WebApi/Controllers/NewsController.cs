using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MuctrService.Application.SQRS.News.Commands.CreateNews;
using MuctrService.Application.SQRS.News.Commands.DeleteNews;
using MuctrService.Application.SQRS.News.Commands.UpdateNews;
using MuctrService.Application.SQRS.News.Queries.GetNewsDetails;
using MuctrService.Application.SQRS.News.Queries.GetNewsList;
using MuctrService.WebApi.Models.News;
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

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            var command = _mapper.Map<CreateNewsCommand>(createNewsDto);

            var newsId = await Mediator.Send(command);

            return Ok(newsId);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            var command = _mapper.Map<UpdateNewsCommand>(updateNewsDto);

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
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
