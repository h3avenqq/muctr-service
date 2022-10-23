using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventDetails
{
    public class GetEventDetailsQueryHandler : IRequestHandler<GetEventDetailsQuery, EventDetailsVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventDetailsQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventDetailsVm> Handle(GetEventDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Events.FirstOrDefaultAsync(events =>
                    events.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new Exception();

            return _mapper.Map<EventDetailsVm>(entity);
        }
    }
}
