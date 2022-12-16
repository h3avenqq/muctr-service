using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyList
{
    public class GetFacultyListQueryHandler : IRequestHandler<GetFacultyListQuery, FacultyListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFacultyListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FacultyListVm> Handle(GetFacultyListQuery request, CancellationToken cancellationToken)
        {
            var facultyQuery =
                await _dbContext.Faculties
                    .ProjectTo<FacultyLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new FacultyListVm { Faculties = facultyQuery };
        }
    }
}
