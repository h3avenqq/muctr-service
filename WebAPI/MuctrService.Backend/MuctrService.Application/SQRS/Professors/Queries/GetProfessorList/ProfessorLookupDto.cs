using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;

namespace MuctrService.Application.SQRS.Professors.Queries.GetProfessorList
{
    public class ProfessorLookupDto : IMapWith<Professor>
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Guid DepartmentId { get; set; }
        public string Position { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Professor, ProfessorLookupDto>()
                .ForMember(pDto => pDto.Id,
                    opt => opt.MapFrom(p => p.Id))
                .ForMember(pDto => pDto.Surname,
                    opt => opt.MapFrom(p => p.Surname))
                .ForMember(pDto => pDto.FirstName,
                    opt => opt.MapFrom(p => p.FirstName))
                .ForMember(pDto => pDto.SecondName,
                    opt => opt.MapFrom(p => p.SecondName))
                .ForMember(pDto => pDto.DepartmentId,
                    opt => opt.MapFrom(p => p.Department.Id))
                .ForMember(pDto => pDto.Position,
                    opt => opt.MapFrom(p => p.Position))
                .ForMember(pDto => pDto.PhoneNumber,
                    opt => opt.MapFrom(p => p.PhoneNumber))
                .ForMember(pDto => pDto.Email,
                    opt => opt.MapFrom(p => p.Email));
        }
    }
}
