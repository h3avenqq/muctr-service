using System;
using System.Collections.Generic;

namespace MuctrService.Domain
{
    public class EducationType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public IList<Schedule> Schedules { get; set; }
    }
}
