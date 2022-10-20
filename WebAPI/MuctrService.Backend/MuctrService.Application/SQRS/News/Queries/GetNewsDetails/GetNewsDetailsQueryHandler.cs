using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQueryHandler : IRequestHandler<GetNewsDetailsQuery, NewsDetailsVm>
    {
        private readonly IMapper _mapper;
        private readonly IMuctrServiceDbContext _dbContext;

        public GetNewsDetailsQueryHandler(IMapper mapper, IMuctrServiceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<NewsDetailsVm> Handle(GetNewsDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.News.FirstOrDefaultAsync(news =>
                    news.Id == request.Id, cancellationToken);

            //сделай кастомный экспепшн
            if (entity == null)
                throw new Exception();

            return _mapper.Map<NewsDetailsVm>(entity);
        }
    }
}
