using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.Events.Commands.DeleteEvent
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public DeleteEventCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Events.FindAsync(new object[] { request.Id });

            if (entity == null)
                throw new Exception();

            _dbContext.Events.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);


            return Unit.Value;
        }
    }
}
