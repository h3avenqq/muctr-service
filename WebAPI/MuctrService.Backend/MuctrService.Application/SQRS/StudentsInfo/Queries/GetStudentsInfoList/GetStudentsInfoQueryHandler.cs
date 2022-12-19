using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentInfoList;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentsInfoList
{
    public class GetStudentsInfoQueryHandler : IRequestHandler<GetStudentsInfoQuery, StudentsInfoVm>
    {
        private readonly IMapper _mapper;
        private readonly IMuctrServiceDbContext _dbContext;

        public GetStudentsInfoQueryHandler(IMapper mapper, IMuctrServiceDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<StudentsInfoVm> Handle(GetStudentsInfoQuery request, CancellationToken cancellationToken)
        {
            var studentsInfoQuery =
                await _dbContext.StudentsInfo.ProjectTo<StudentsInfoDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new StudentsInfoVm { StudentsInfo = studentsInfoQuery };
        }
    }
}
