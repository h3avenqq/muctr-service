using MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentInfoList;
using System.Collections.Generic;

namespace MuctrService.Application.SQRS.StudentsInfo.Queries.GetStudentsInfoList
{
    public class StudentsInfoVm
    {
        public IList<StudentsInfoDto> StudentsInfo { get; set; }
    }
}
