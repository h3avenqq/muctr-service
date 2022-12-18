using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Schedules.Queries.GetScheduleList
{
    public class GetScheduleListQueryHandler : IRequestHandler<GetScheduleListQuery, ScheduleListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetScheduleListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ScheduleListVm> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
        {
            var sheduleQuery =
                await _dbContext.Schedules.ProjectTo<ScheduleLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new ScheduleListVm { Schedules = sheduleQuery };
        }
    }
}
