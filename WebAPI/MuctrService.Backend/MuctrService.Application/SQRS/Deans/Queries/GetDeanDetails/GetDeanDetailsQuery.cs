using MediatR;
using System;

namespace MuctrService.Application.SQRS.Deans.Queries.GetDeanDetails
{
    public class GetDeanDetailsQuery : IRequest<DeanDetailsVm>
    {
        public Guid FacultyId { get; set; }
    }
}
