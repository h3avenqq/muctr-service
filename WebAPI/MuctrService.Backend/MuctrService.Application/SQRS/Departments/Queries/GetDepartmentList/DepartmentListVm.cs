using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Departments.Queries.GetDepartmentList
{
    public class DepartmentListVm
    {
        public IList<DepartmentLookupDto> Departments { get; set; }
    }
}
