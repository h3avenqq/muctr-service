using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyList
{
    public class FacultyLookupDto : IMapWith<Faculty>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Faculty, FacultyLookupDto>()
                .ForMember(fVm => fVm.Id,
                    opt => opt.MapFrom(f => f.Id))
                .ForMember(fVm => fVm.Name,
                    opt => opt.MapFrom(f => f.Name))
                .ForMember(fVm => fVm.Description,
                    opt => opt.MapFrom(f => f.Description));
        }
    }
}

