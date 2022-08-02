using DomainService.Enum;

namespace DomainService.Request
{
    public class PersonRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenreEnum Genre { get; set; }
        public string FotoUrl { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
        public String Password { get; set; }
    }
}