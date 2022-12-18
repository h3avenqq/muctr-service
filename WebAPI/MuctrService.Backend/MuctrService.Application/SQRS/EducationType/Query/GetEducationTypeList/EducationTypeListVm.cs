using System.Collections.Generic;

namespace MuctrService.Application.SQRS.EducationType.Query.GetEducationTypeList
{
    public class EducationTypeListVm
    {
        public IList<EducationTypeLookupDto> EducationTypes { get; set; }
    }
}
