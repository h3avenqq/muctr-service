using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Application.SQRS.News.Commands.CreateNews;

namespace MuctrService.WebApi.Models.News
{
    public class CreateNewsDto : IMapWith<CreateNewsCommand>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsCommand>()
                .ForMember(newsCommand => newsCommand.Title,
                    opt => opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(newsCommand => newsCommand.Description,
                    opt => opt.MapFrom(newsDto => newsDto.Description))
                .ForMember(newsCommand => newsCommand.MediaUrl,
                    opt => opt.MapFrom(newsDto => newsDto.MediaUrl));
        }
    }
}
