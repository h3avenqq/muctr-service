using System;
using MediatR;

namespace MuctrService.Application.SQRS.News.Commands.UpdateNews
{
    public class UpdateNewsCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string MediaUrl { get; set; }
    }
}
