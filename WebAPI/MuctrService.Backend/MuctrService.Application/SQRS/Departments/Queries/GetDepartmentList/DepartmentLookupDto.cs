using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Departments.Queries.GetDepartmentList
{
    public class DepartmentLookupDto : IMapWith<Department>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentLookupDto>()
                .ForMember(dDto => dDto.Id,
                    opt => opt.MapFrom(d => d.Id))
                .ForMember(dDto => dDto.Name,
                    opt => opt.MapFrom(d => d.Name));
        }

    }
}
