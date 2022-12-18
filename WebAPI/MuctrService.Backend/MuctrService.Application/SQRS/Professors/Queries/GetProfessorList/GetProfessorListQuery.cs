using MediatR;
using System;

namespace MuctrService.Application.SQRS.Professors.Queries.GetProfessorList
{
    public class GetProfessorListQuery : IRequest<ProfessorListVm>
    {
        public Guid FacultuId { get; set; }
    }
}
