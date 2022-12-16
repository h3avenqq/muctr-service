using System;
using System.ComponentModel.DataAnnotations;

namespace MuctrService.Domain
{
    public class Professor
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public Department Department { get; set; }
        public string Position { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
