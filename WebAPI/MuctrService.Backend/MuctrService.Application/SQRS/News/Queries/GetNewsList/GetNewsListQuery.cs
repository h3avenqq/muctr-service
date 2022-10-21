using MediatR;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsList
{
    public class GetNewsListQuery : IRequest<NewsListVm>
    {
        public int Limit { get; set; }
    }
}
