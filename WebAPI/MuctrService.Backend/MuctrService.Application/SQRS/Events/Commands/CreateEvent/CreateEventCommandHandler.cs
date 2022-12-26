using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MuctrService.Application.Interfaces;
using MuctrService.Domain;

namespace MuctrService.Application.SQRS.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IMuctrServiceDbContext _dbContext;

        public CreateEventCommandHandler(IMuctrServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = new Event()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                PublicationDate = DateTime.Now,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                MediaUrl = request.MediaUrl
            };

            await _dbContext.Events.AddAsync(newEvent, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return newEvent.Id;
        }
    }
}
