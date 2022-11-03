using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.News.Commands.DeleteNews
{
    public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public DeleteNewsCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.News.FindAsync(new object[] { request.Id });

            if (entity == null)
                throw new Exception();

            _dbContext.News.Remove(entity);

            await _dbContext.SaveChangesAsync(cancellationToken);
            

            return Unit.Value;
        }
    }
}
