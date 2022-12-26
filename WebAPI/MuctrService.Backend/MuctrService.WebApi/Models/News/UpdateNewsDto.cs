using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Application.SQRS.News.Commands.UpdateNews;
using System;

namespace MuctrService.WebApi.Models.News
{
    public class UpdateNewsDto : IMapWith<UpdateNewsCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNewsCommand>()
                .ForMember(commandNews => commandNews.Id,
                    opt => opt.MapFrom(newsDto => newsDto.Id))
                .ForMember(commandNews => commandNews.Title,
                    opt => opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(commandNews => commandNews.Description,
                    opt => opt.MapFrom(newsDto => newsDto.Description))
                .ForMember(commandNews => commandNews.MediaUrl,
                    opt => opt.MapFrom(newsDto => newsDto.MediaUrl));

        }
    }
}
