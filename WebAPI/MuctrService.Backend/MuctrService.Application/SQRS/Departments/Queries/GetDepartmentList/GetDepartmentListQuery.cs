using MediatR;
using System;

namespace MuctrService.Application.SQRS.Departments.Queries.GetDepartmentList
{
    public class GetDepartmentListQuery : IRequest<DepartmentListVm>
    {
        public Guid FacultyId { get; set; }
    }
}
