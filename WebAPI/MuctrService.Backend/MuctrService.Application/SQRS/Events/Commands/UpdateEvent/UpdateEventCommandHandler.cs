using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public UpdateEventCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Events.FirstOrDefaultAsync(evnt => evnt.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new Exception();

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.StartTime = request.StartTime;
            entity.EndTime = request.EndTime;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
