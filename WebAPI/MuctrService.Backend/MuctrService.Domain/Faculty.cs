using System;
using System.Collections.Generic;

namespace MuctrService.Domain
{
    public class Faculty
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Department> Departments { get; set; }
    }
}
