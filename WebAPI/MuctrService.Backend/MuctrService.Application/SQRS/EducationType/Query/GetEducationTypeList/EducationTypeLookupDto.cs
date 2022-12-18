using AutoMapper;
using MuctrService.Application.Common.Mappings;
using System;

namespace MuctrService.Application.SQRS.EducationType.Query.GetEducationTypeList
{
    public class EducationTypeLookupDto : IMapWith<Domain.EducationType>//втф блять опять неймспейс только подставляется какого блять хуя
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.EducationType, EducationTypeLookupDto>()
                .ForMember(etDto => etDto.Id,
                    opt => opt.MapFrom(et => et.Id))
                .ForMember(etDto => etDto.Name,
                    opt => opt.MapFrom(et => et.Name));
        }
    }
}
