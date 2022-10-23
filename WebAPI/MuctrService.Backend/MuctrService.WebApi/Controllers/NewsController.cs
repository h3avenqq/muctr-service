using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        //TODO: Надо зарефакторить это все как нить через перегрузки а то на хуйню похоже
        //да и написано что возвращает NewsDetailsVm а по факту может и другую хуйню вернуть ы
        [HttpGet]
        public async Task<ActionResult<NewsDetailsVm>> Get(Guid id, int? limit)
        {
            if (id != Guid.Empty)
            {
                var query = new GetNewsDetailsQuery
                {
                    Id = id
                };

                var vm = await Mediator.Send(query);

                return Ok(vm);
            }
            else if (limit is not null)
            {
                var query = new GetNewsListQuery
                {
                    Limit = (int)limit
                };

                var vm = await Mediator.Send(query);

                return Ok(vm);
            }

            return NotFound();
        }
    }
}
