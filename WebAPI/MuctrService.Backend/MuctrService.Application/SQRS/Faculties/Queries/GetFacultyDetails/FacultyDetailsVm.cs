using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;
using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyDetails
{
    public class FacultyDetailsVm : IMapWith<Faculty>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Department> Departments { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Faculty, FacultyDetailsVm>()
                .ForMember(fVm => fVm.Id,
                    opt => opt.MapFrom(f => f.Id))
                .ForMember(fVm => fVm.Name,
                    opt => opt.MapFrom(f => f.Name))
                .ForMember(fVm => fVm.Description,
                    opt => opt.MapFrom(f => f.Description))
                .ForMember(fVm=>fVm.Departments,
                    opt=>opt.MapFrom(f=>f.Departments));
        }
    }
}
