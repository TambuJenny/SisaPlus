using DomainService.Models;

namespace DomainService.Response
{
    public class StudentResponse
    {
        public Guid Id { get; set; }
        public PersonModel Person { get; set; }
        public string StudentNumber { get; set; }
        public int AcademicLevel { get; set; }
        public CourseModel Course { get; set; }
    }
}
