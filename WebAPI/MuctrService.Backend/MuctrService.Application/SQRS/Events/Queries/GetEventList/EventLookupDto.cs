using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Application.SQRS.Events.Queries.GetEventDetails;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventList
{
    public class EventLookupDto : IMapWith<Event>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Event, EventLookupDto>()
                .ForMember(eventDto => eventDto.Id,
                    opt => opt.MapFrom(eventSrc => eventSrc.Id))
                .ForMember(eventDto => eventDto.Title,
                    opt => opt.MapFrom(eventSrc => eventSrc.Title))
                .ForMember(eventDto => eventDto.Description,
                    opt => opt.MapFrom(eventSrc => eventSrc.Description))
                .ForMember(eventDto => eventDto.PublicationDate,
                    opt => opt.MapFrom(eventSrc => eventSrc.PublicationDate))
                .ForMember(eventDto => eventDto.StartTime,
                    opt => opt.MapFrom(eventSrc => eventSrc.StartTime))
                .ForMember(eventDto => eventDto.EndTime,
                    opt => opt.MapFrom(eventSrc => eventSrc.EndTime))
                .ForMember(eventDto => eventDto.MediaUrl,
                    opt => opt.MapFrom(eventSrc => eventSrc.MediaUrl));
        }
    }
}
