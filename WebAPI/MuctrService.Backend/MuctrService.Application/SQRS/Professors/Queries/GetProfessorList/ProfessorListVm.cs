using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Professors.Queries.GetProfessorList
{
    public class ProfessorListVm
    {
        public IList<ProfessorLookupDto> Professors { get; set; }
    }
}
