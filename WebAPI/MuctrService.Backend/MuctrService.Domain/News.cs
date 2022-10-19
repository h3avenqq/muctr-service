using System;

namespace MuctrService.Domain
{
    public class News
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublicationDate { get; set; }
        public string MediaUrl { get; set; }

    }
}
