using MediatR;
using System;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsDetails
{
    public class GetNewsDetailsQuery : IRequest<NewsDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
