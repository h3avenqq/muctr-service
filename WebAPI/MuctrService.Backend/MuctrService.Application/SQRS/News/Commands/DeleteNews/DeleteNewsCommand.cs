using System;
using MediatR;

namespace MuctrService.Application.SQRS.News.Commands.DeleteNews
{
    public class DeleteNewsCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
