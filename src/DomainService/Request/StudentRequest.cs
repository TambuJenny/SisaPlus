using DomainService.Models;

namespace DomainService.Request
{
    public class StudentRequest
    {
        public Guid Person { get; set; }
        public string StudentNumber { get; set; }
        public int AcademicLevel { get; set; }
        public Guid Course { get; set; }
    }
}
