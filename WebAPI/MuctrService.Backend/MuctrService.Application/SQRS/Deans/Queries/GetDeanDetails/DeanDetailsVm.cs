using AutoMapper;
using MuctrService.Application.Common.Mappings;
using MuctrService.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuctrService.Application.SQRS.Deans.Queries.GetDeanDetails
{
    public class DeanDetailsVm : IMapWith<Dean>
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string MediaUrl { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Dean, DeanDetailsVm>()
                .ForMember(dVm => dVm.Id,
                    opt => opt.MapFrom(d => d.Id))
                .ForMember(dVm => dVm.Surname,
                    opt => opt.MapFrom(d => d.Surname))
                .ForMember(dVm => dVm.FirstName,
                    opt => opt.MapFrom(d => d.FirstName))
                .ForMember(dVm => dVm.SecondName,
                    opt => opt.MapFrom(d => d.SecondName))
                .ForMember(dVm => dVm.PhoneNumber,
                    opt => opt.MapFrom(d => d.PhoneNumber))
                .ForMember(dVm => dVm.Email,
                    opt => opt.MapFrom(d => d.Email))
                .ForMember(dVm => dVm.MediaUrl,
                    opt => opt.MapFrom(d => d.MediaUrl));
        }
    }
}
