using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Schedules.Queries.GetScheduleList
{
    public class ScheduleListVm
    {
        public IList<ScheduleLookupDto> Schedules { get; set; }
    }
}
