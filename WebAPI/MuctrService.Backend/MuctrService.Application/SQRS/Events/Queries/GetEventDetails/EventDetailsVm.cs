using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventDetails
{
    public class EventDetailsVm : IMapWith<Event>
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
            profile.CreateMap<Event, EventDetailsVm>()
                .ForMember(eventVm => eventVm.Id,
                    opt => opt.MapFrom(eventSrc => eventSrc.Id))
                .ForMember(eventVm => eventVm.Title,
                    opt => opt.MapFrom(eventSrc => eventSrc.Title))
                .ForMember(eventVm => eventVm.Description,
                    opt => opt.MapFrom(eventSrc => eventSrc.Description))
                .ForMember(eventVm => eventVm.PublicationDate,
                    opt => opt.MapFrom(eventSrc => eventSrc.PublicationDate))
                .ForMember(eventVm => eventVm.StartTime,
                    opt => opt.MapFrom(eventSrc => eventSrc.StartTime))
                .ForMember(eventVm => eventVm.EndTime,
                    opt => opt.MapFrom(eventSrc => eventSrc.EndTime))
                .ForMember(eventVm => eventVm.MediaUrl,
                    opt => opt.MapFrom(eventSrc => eventSrc.MediaUrl));
        }
    }
}
