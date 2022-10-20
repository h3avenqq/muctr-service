using System.Collections.Generic;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsList
{
    public class NewsListVm
    {
        public IList<NewsLookupDto> News { get; set; }
    }
}
