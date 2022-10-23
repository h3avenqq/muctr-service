using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsList
{
    public class GetNewsListQueryHandler : IRequestHandler<GetNewsListQuery, NewsListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNewsListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<NewsListVm> Handle(GetNewsListQuery request, CancellationToken cancellationToken)
        {
            Console.WriteLine("Ищу новости епт!");

            var newsQuery =
                await _dbContext.News.OrderByDescending(news => news.PublicationDate)
                    .Take(request.Limit).AsQueryable().ProjectTo<NewsLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new NewsListVm { News = newsQuery };
        }
    }
}
