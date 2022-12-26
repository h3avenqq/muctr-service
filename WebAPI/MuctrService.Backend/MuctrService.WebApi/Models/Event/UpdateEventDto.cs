using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Application.SQRS.Events.Commands.UpdateEvent;
using System;

namespace MuctrService.WebApi.Models.Event
{
    public class UpdateEventDto : IMapWith<UpdateEventCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateEventDto, UpdateEventCommand>()
                .ForMember(eventCommand => eventCommand.Id,
                    opt => opt.MapFrom(eventDto => eventDto.Id))
                .ForMember(eventCommand => eventCommand.Title,
                    opt => opt.MapFrom(eventDto => eventDto.Title))
                .ForMember(eventCommand => eventCommand.Description,
                    opt => opt.MapFrom(eventDto => eventDto.Description))
                .ForMember(eventCommand => eventCommand.StartTime,
                    opt => opt.MapFrom(eventDto => eventDto.StartTime))
                .ForMember(eventCommand => eventCommand.EndTime,
                    opt => opt.MapFrom(eventDto => eventDto.EndTime))
                .ForMember(eventCommand => eventCommand.MediaUrl,
                    opt => opt.MapFrom(eventDto => eventDto.MediaUrl));
        }
    }
}
