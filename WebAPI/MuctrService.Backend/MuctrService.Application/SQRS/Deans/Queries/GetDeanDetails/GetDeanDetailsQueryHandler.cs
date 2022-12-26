using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Deans.Queries.GetDeanDetails
{
    public class GetDeanDetailsQueryHandler : IRequestHandler<GetDeanDetailsQuery, DeanDetailsVm>
    {
        private readonly IMuctrServiceDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetDeanDetailsQueryHandler(IMuctrServiceDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DeanDetailsVm> Handle(GetDeanDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext.Deans.FirstOrDefaultAsync(dean => dean.FacultyId == request.FacultyId, cancellationToken);

            if (entity == null)
                throw new Exception();

            return _mapper.Map<DeanDetailsVm>(entity);
        }
    }
}
