using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MuctrService.Application.Interfaces;

namespace MuctrService.Application.SQRS.News.Commands.UpdateNews
{
    public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public UpdateNewsCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.News.FirstOrDefaultAsync(news => news.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new Exception();

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.MediaUrl = request.MediaUrl;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
