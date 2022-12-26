using System;
using System.ComponentModel.DataAnnotations;

namespace MuctrService.Domain
{
    public class Dean
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Faculty Faculty { get; set; }
        public Guid FacultyId { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string MediaUrl { get; set; }
    }
}
