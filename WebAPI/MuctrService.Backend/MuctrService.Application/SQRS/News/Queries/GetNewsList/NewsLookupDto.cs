using System;
using AutoMapper;
using MuctrService.Application.Common.Mappings;

namespace MuctrService.Application.SQRS.News.Queries.GetNewsList
{
    public class NewsLookupDto : IMapWith<Domain.News>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.News, NewsLookupDto>()
                .ForMember(newsDto => newsDto.Id,
                    opt => opt.MapFrom(news => news.Id))
                .ForMember(newsDto => newsDto.Title,
                    opt => opt.MapFrom(news => news.Title))
                .ForMember(newsDto => newsDto.Description,
                    opt => opt.MapFrom(news => news.Description))
                .ForMember(newsDto => newsDto.PublicationDate,
                    opt => opt.MapFrom(news => news.PublicationDate))
                .ForMember(newsDto => newsDto.MediaUrl,
                    opt => opt.MapFrom(news => news.MediaUrl));
        }
    }
}
