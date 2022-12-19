using AutoMapper;
using MuctrService.Application.Common.Mappings;
using System;

namespace MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentInfoList
{
    public class StudentsInfoDto : IMapWith<Domain.StudentsInfo>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.StudentsInfo, StudentsInfoDto>()
                .ForMember(siDto => siDto.Id,
                    opt => opt.MapFrom(si => si.Id))
                .ForMember(siDto => siDto.Name,
                    opt => opt.MapFrom(si => si.Name))
                .ForMember(siDto => siDto.Description,
                    opt => opt.MapFrom(si => si.Description));
        }
    }
}
