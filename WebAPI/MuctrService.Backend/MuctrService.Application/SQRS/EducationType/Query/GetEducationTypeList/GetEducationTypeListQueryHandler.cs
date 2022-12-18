using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.EducationType.Query.GetEducationTypeList
{
    public class GetEducationTypeListQueryHandler : IRequestHandler<GetEducationTypeListQuery, EducationTypeListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetEducationTypeListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<EducationTypeListVm> Handle(GetEducationTypeListQuery request, CancellationToken cancellationToken)
        {
            var educationTypeQuery =
                await _dbContext.EducationTypes.ProjectTo<EducationTypeLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new EducationTypeListVm { EducationTypes = educationTypeQuery };
        }
    }
}
