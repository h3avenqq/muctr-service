using System;
using System.Collections.Generic;

namespace MuctrService.Domain
{
    public class Department
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public IList<Professor> Professors { get; set; }
    }
}
