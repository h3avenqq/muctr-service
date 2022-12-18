using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQueryHandler : IRequestHandler<GetDepartmentListQuery, DepartmentListVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDepartmentListQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DepartmentListVm> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
        {
            var departmentsQuery =
                await _dbContext.Departments.Where(x => x.Faculty.Id == request.FacultyId)
                    .ProjectTo<DepartmentLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new DepartmentListVm { Departments = departmentsQuery };
        }
    }
}
