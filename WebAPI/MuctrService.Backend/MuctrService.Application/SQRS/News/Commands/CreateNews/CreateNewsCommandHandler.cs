using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuctrService.Application.Interfaces;
using MuctrService.Domain;


namespace MuctrService.Application.SQRS.News.Commands.CreateNews
{
    public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, Guid>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public CreateNewsCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();

            var news = new Domain.News()//что за хуйня нахуй тут домейн...
            {
                Id = id,
                Title = request.Title,
                Description = request.Description,
                PublicationDate = DateTime.Now,
                MediaUrl = "/" + id
            };

            await _dbContext.News.AddAsync(news, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return news.Id;
        }
    }
}
