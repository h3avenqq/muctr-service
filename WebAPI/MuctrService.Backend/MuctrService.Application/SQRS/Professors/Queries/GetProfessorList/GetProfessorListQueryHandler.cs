using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Professors.Queries.GetProfessorList
{
    public class GetProfessorListQueryHandler : IRequestHandler<GetProfessorListQuery, ProfessorListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetProfessorListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ProfessorListVm> Handle(GetProfessorListQuery request, CancellationToken cancellationToken)
        {
            var professorsQuery =
                await _dbContext.Professors.Where(x => x.Department.Faculty.Id == request.FacultuId)
                    .ProjectTo<ProfessorLookupDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);

            return new ProfessorListVm { Professors = professorsQuery };
        }
    }
}
