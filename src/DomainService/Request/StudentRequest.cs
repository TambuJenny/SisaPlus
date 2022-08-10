using DomainService.Models;

namespace DomainService.Request
{
    public class StudentRequest
    {
        public PersonModel Person { get; set; }
        public string StudentNumber { get; set; }
        public int AcademicLevel { get; set; }
        public CourseModel Course { get; set; }
    }
}
