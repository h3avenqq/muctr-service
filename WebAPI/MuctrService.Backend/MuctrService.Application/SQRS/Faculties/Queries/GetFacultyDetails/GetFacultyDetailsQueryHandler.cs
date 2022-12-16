using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyDetails
{
    public class GetFacultyDetailsQueryHandler : IRequestHandler<GetFacultiesDetailsQuery, FacultyDetailsVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFacultyDetailsQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FacultyDetailsVm> Handle(GetFacultiesDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Faculties.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (entity == null)
                throw new Exception();

            return _mapper.Map<FacultyDetailsVm>(entity);
        }
    }
}
