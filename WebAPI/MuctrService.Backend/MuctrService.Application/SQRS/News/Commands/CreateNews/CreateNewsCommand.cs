using MediatR;
using System;

namespace MuctrService.Application.SQRS.News.Commands.CreateNews
{
    public class CreateNewsCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }
    }
}
