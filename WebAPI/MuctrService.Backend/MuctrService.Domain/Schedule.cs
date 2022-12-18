using System;

namespace MuctrService.Domain
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime PublicationDate { get; set; }
        public EducationType EducationType { get; set; }
    }
}
