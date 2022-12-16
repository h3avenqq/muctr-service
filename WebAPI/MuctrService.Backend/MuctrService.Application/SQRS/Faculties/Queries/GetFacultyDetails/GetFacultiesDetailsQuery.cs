using System;
using MediatR;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyDetails
{
    public class GetFacultiesDetailsQuery : IRequest<FacultyDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
