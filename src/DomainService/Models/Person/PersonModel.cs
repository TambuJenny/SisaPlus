using System;
using DomainService.Enum;

namespace DomainService.Models
{
    public class PersonModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenreEnum Genre { get; set; }
        public string FotoUrl { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Password { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } = DateTime.Now;
    }
}
