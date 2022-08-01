using DomainService.Enum;

namespace DomainService.DTO
{
    public class PersonDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public GenreEnum Genre { get; set; }
        public string FotoUrl { get; set; }
        public string Description { get; set; }
        public string Email { get; set; }
        public String PhoneNumber { get; set; }
    }
}
