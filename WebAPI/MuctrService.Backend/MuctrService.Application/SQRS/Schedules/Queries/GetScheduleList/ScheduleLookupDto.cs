using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Schedules.Queries.GetScheduleList
{
    public class ScheduleLookupDto : IMapWith<Schedule>
    {
        public Guid Id { get; set; }
        public Guid EducationTypeId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime PublicationDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Schedule, ScheduleLookupDto>()
                .ForMember(sDto => sDto.Id,
                    opt => opt.MapFrom(s => s.Id))
                .ForMember(sDto => sDto.EducationTypeId,
                    opt => opt.MapFrom(s => s.EducationType.Id))
                .ForMember(sDto => sDto.Name,
                    opt => opt.MapFrom(s => s.Name))
                .ForMember(sDto => sDto.Url,
                    opt => opt.MapFrom(s => s.Url))
                .ForMember(sDto => sDto.PublicationDate,
                    opt => opt.MapFrom(s => s.PublicationDate));
                
        }
    }
}
