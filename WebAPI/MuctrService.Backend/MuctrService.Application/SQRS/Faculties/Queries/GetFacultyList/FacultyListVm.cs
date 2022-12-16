using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Faculties.Queries.GetFacultyList
{
    public class FacultyListVm
    {
        public IList<FacultyLookupDto> Faculties { get; set; }
    }
}
