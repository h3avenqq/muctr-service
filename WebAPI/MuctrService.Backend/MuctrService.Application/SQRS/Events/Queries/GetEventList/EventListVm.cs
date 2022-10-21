using System.Collections.Generic;

namespace MuctrService.Application.SQRS.Events.Queries.GetEventList
{
    public class EventListVm
    {
        public IList<EventLookupDto> Events { get; set; }
    }
}
