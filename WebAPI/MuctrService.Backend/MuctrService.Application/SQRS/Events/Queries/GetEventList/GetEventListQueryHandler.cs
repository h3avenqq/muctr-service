using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventList
{
    public class GetEventListQueryHandler : IRequestHandler<GetEventListQuery, EventListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEventListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EventListVm> Handle(GetEventListQuery request, CancellationToken cancellationToken)
        {
            List<EventLookupDto> eventsQuery;
            if (request.Unfinished)
                eventsQuery =
                    await _dbContext.Events.Where(events => events.EndTime > DateTime.Today)
                        .OrderByDescending(events => events.PublicationDate).Take(request.Limit)
                        .AsQueryable().ProjectTo<EventLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);
            else
                eventsQuery =
                    await _dbContext.Events.OrderByDescending(events => events.PublicationDate)
                        .Take(request.Limit).AsQueryable().ProjectTo<EventLookupDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken);

            return new EventListVm { Events = eventsQuery };
        }
    }
}
