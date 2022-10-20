using AutoMapper;
using MuctrService.Application.Common.Mappings;
using System;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsDetails
{
    public class NewsDetailsVm : IMapWith<Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.News, NewsDetailsVm>()
                .ForMember(newsVm => newsVm.Id,
                    opt => opt.MapFrom(news => news.Id))
                .ForMember(newsVm => newsVm.Title,
                    opt => opt.MapFrom(news => news.Title))
                .ForMember(newsVm => newsVm.Description,
                    opt => opt.MapFrom(news => news.Description))
                .ForMember(newsVm => newsVm.PublicationDate,
                    opt => opt.MapFrom(news => news.PublicationDate))
                .ForMember(newsVm => newsVm.MediaUrl,
                    opt => opt.MapFrom(news => news.MediaUrl));
        }
    }
}
